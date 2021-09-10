using NFLInfoCenter.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NFLInfoCenter.Forms
{
    public partial class FrmReceiptsPrinter : Form
    {
        private Station station;
        private DysonDB dysonData;
        private System.Windows.Forms.Form commingFrom;
        private string selection;
        private List<Receipt> receiptList = new List<Receipt>();
        private List<PreReceipts> prereceiptList = new List<PreReceipts>();
        private List<Receipt> printedReceipts = new List<Receipt>();
        private List<PreReceipts> printedPreceipts = new List<PreReceipts>();
        
        
        private List<Receipt> fullReceiptListCollected = new List<Receipt>();
        private List<PreReceipts> fullPreReceiptListCollected = new List<PreReceipts>();
        private List<Receipt> re_initialList = new List<Receipt>();
        private List<PreReceipts> pre_initialList = new List<PreReceipts>();
        private List<Receipt> buffer = new List<Receipt>();
        Printer p;

        private Size compact_size = new Size(400,40);
        private Size full_size = new Size(400, 580);
        private Size expand_left = new Size(715, 580);

        private int receiptsCollected;
        private int receiptsQueued;

        private int prereceiptsCollected;
        private int prereceiptsQueued;

        string[] dysonStations;

        public FrmReceiptsPrinter(System.Windows.Forms.Form commingFrom)
        {
            InitializeComponent();
            /*
             * Instantiating previous form
             */
            this.commingFrom = commingFrom;

            /*
             * Instanting data source of Dyson data
             */
            dysonData = new DysonDB(commingFrom);
            dysonData.Open();

            /*
             * Instantiate Printer class object
             */
            p = new Printer(this, printer);

            /*
             * Get complete list of workstations
             */
            dysonStations = dysonData.getActiveStations();
            setStationsList(dysonStations);

            /*
             * Initial setup of station name using hostname
             */
            station = new Station(this);
            setSelectedStation(station.name);


            /*
             * Initial setup of printer name according to Station Name
             */
            if(station.name == "REC-ST11")
            {
                p.setPrinterName("zebrawifiprinter");
                setPrinterName(p.printerName);
            }
            else
            {
                p.setPrinterName("zebralocalprinter");
                setPrinterName(p.printerName);
            }
        }

        public void initForm()
        {
            timer1.Enabled = true;
            compactView();
            setLocation();
            /*
             * Initial Printing Preferences
             * checkBoxActivatePrints: Enables app to queue print tasks
             * checkBoxAutomatic: Enables automatic dequeue of print tasks
             */
            checkBoxAutomatic.Checked = true;
            checkBoxActivatePrints.Checked = true;
            /*
             * Display printer name
             */
            setPrinterName(p.printerName);

            

        }


        #region Controls
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FrmCloseMenu closeMenu = new FrmCloseMenu(this, commingFrom);
                closeMenu.Show();
            }
            else
            {
                this.Show();
            }
        }
        private void textBoxRMA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataReceiptsView.Rows.Clear();
            }
        }
        private void textBoxRMA_TextChanged(object sender, EventArgs e)
        {
            dataReceiptsView.Rows.Clear();
        }
        private void textBoxRMA2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (station.name.Contains("Pre Receiving") ||
                    station.name.Contains("Leija"))
                {
                    ManualPrint_PreReceipts(get_rma_2());
                }
                else
                {
                    Console.WriteLine("1 receipts manual printing");
                    ManualPrint_Receipts(get_rma_2());
                }

            }
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            List<Object> selectedReceipts = getSelectedPrints();
            MsgTypes.printme(MsgTypes.msg_success, "printing selected reciepts. Qty: " + selectedReceipts.Count, this);
            Console.WriteLine("printing selected reciepts. Qty: " + selectedReceipts.Count);
            if(selection.Contains("Pre Receiving") || selection.Contains("Leija"))
            {
                ManualPrint_PreReceipts(get_rma());
            }
            else
            {
                ManualPrint_Receipts(get_rma());
            }
            
        }
        private void init_receiptDatagridView()
        {
            DataGridView dv = dataReceiptsView;
            dv.ColumnCount = 13;
            dv.Columns[0].Name = "Tote";
            dv.Columns[1].Name = "SKU";
            dv.Columns[2].Name = "Qty";
            dv.Columns[3].Name = "RMA Number";
            dv.Columns[4].Name = "Channel";
            dv.Columns[5].Name = "Station";
            dv.Columns[6].Name = "Employee";
            dv.Columns[7].Name = "COO";
            dv.Columns[8].Name = "Disposition";
            dv.Columns[9].Name = "RMAType";
            dv.Columns[10].Name = "Scan Time";
            dv.Columns[11].Name = "Serial Number";
            dv.Columns[12].Name = "ReceiptId";
            initDefaultsDataGrid(dv);
        }
        public void init_prereceiptDataGridView()
        {
            DataGridView dv = dataReceiptsView;
            dv.ColumnCount = 9;
            dv.Columns[0].Name = "Id";
            dv.Columns[1].Name = "RMA";
            dv.Columns[2].Name = "TrackingNumber";
            dv.Columns[3].Name = "Pallets";
            dv.Columns[4].Name = "Boxes";
            dv.Columns[5].Name = "PreReceiptedOn";
            dv.Columns[6].Name = "Station";
            dv.Columns[7].Name = "Channel";
            dv.Columns[8].Name = "Item";
            initDefaultsDataGrid(dv);
        }
        public void initDefaultsDataGrid(DataGridView dv)
        {
            dv.EnableHeadersVisualStyles = false;
            dv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dv.DefaultCellStyle.BackColor = Color.Black;
            dv.DefaultCellStyle.ForeColor = SystemColors.ButtonFace;
            dv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ButtonFace;
            dv.DefaultCellStyle.Font = new Font("Times New Roman", 8, FontStyle.Regular);
            dv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Rows.Clear();
            foreach (DataGridViewColumn col in dv.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }
        private void pictureBoxBackToMenu_MouseEnter(object sender, EventArgs e)
        {
            CustomEffects effects = new CustomEffects(this);

            effects.hoverButtonEffect(this,
                                    pictureBoxBackToMenu,
                                    Properties.Resources.backToMainImage.ToString(),
                                    Properties.Resources.backToMainImageHighlighted.ToString());
        }
        private void pictureBoxBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            CustomEffects effects = new CustomEffects(this);

            effects.resetButtonColor(this,
                                    pictureBoxBackToMenu,
                                    Properties.Resources.backToMainImage.ToString(),
                                    Properties.Resources.backToMainImageHighlighted.ToString());
        }
        private void FrmReceiptsPrinter_Load(object sender, EventArgs e)
        {
            initForm();
            MsgTypes.printme(MsgTypes.msg_success, "printing tool running", commingFrom);
        }
        private void pictureBoxBackToMenu_Click(object sender, EventArgs e)
        {
            commingFrom.Show();
            commingFrom.WindowState = FormWindowState.Normal;
            this.Hide();
        }      
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                updateReceipts();
                highlightSelection(this.selection);   
                if(selection.Contains("Pre Receiving") || selection.Contains("Leija"))
                {
                    if (pre_initialList.Count == 0)
                        pre_initialList.AddRange(fullPreReceiptListCollected);
                    PreReceipts lastAdded = prereceiptList.First();

                    if (checkBoxActivatePrints.Checked
                       && !listContainsPreReceipts(lastAdded, pre_initialList))
                    {
                        prereceiptsCollected += 1;
                    }

                    if (checkBoxActivatePrints.Checked
                        && !listContainsPreReceipts(lastAdded, pre_initialList)
                        && !listContainsPreReceipts(lastAdded, listViewQueue)
                        && !listContainsPreReceipts(lastAdded, printedPreceipts)) // checking of sn is already in printed list.
                    {

                        addPreReceiptToPrintQueue(lastAdded);

                        //addAllReceipts(prereceiptList); //this is to pull full query into queue list.
                    }


                    prereceiptsQueued = listViewQueue.Items.Count;
                    labelCollected.Text = "collected: " + fullPreReceiptListCollected.Count;
                    labelQueued.Text = "queued: " + prereceiptsQueued;
                    labelLoss.Text = "loss: " + (prereceiptsQueued - listViewQueue.Items.Count).ToString();
                }
                else
                {
                    if (re_initialList.Count == 0)
                        re_initialList.AddRange(fullReceiptListCollected);

                    Receipt lastAdded = receiptList.First();
                    if (checkBoxActivatePrints.Checked
                       && !listContainsReceipt(lastAdded, re_initialList))
                    {
                        receiptsCollected += 1;
                    }
                    if (checkBoxActivatePrints.Checked
                        && !listContainsReceipt(lastAdded, re_initialList)
                        && !listContainsReceipt(lastAdded, listViewQueue)
                        && !listContainsReceipt(lastAdded, printedReceipts)) // checking of sn is already in printed list.
                    {
                        addReceiptToPrintQueue(lastAdded);
                        //addAllReceipts(receiptList); ///this is to pull full query into queue list.
                    }


                    receiptsQueued = listViewQueue.Items.Count;
                    labelCollected.Text = "collected: " + fullReceiptListCollected.Count;
                    labelQueued.Text = "queued: " + receiptsQueued;
                    labelLoss.Text = "loss: " + (receiptsQueued - listViewQueue.Items.Count).ToString();
                }

                /*
                 * Code section dequeueing items and sending to zebralocalprinter
                 */
                if(checkBoxActivatePrints.Checked & checkBoxAutomatic.Checked)
                {
                    popOldestQueue();
                    
                }
            }
            catch (Exception ex)
            {
                string message = "db connection lost, restoring...";
                MsgTypes.printme(MsgTypes.msg_success, message, this);
                Console.WriteLine(message);

                dysonData = new DysonDB(commingFrom);
                dysonData.Open();
            }
        }
        private void listViewReceipts_Click(object sender, EventArgs e)
        {
            try
            {
                setSelection(listViewReceipts.SelectedItems[0].Text);
            }catch(Exception ex)
            {
                MsgTypes.printme(MsgTypes.msg_success, "oops..some error", this);
            }
        }
        private void checkBoxActivatePrints_CheckedChanged(object sender, EventArgs e)
        {
            if (selection.Contains("Pre Receiving") || selection.Contains("Leija"))
            {
                pre_initialList.AddRange(fullPreReceiptListCollected);
            }
            else
            {
                re_initialList.AddRange(fullReceiptListCollected);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            popOldestQueue();
        }
        private void printer_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Console.WriteLine("15 Starting Print Page event");

            if(getSelectedStation().Contains("Pre Receiving") || 
                getSelectedStation().Contains("Leija"))
            {
                Console.WriteLine("16.1 Error detected PreReceiving print task");
                PreReceipts fifo = new PreReceipts();
                    foreach (PreReceipts item in prereceiptList)
                    {
                        if (item.Id.ToString() == listViewQueue.Items[0].Text)
                        {
                            fifo = item;
                        }
                    }
                    if (p.print(sender, e) & fifo != null)
                    {
                        printedPreceipts.Add(fifo);
                        listViewQueue.Items.RemoveAt(listViewQueue.Items[0].Index);
                    }
            }else
            {
                Console.WriteLine("16.2 Receipt Print task detected");
                Receipt fifo = receiptList.Find(x => x.Id == Int32.Parse(listViewQueue.Items[0].Text));
                Console.WriteLine("17 setting fifo: " + fifo.Sku + " " + fifo.Qty);
                if (p.print(sender, e) & fifo != null)
                {
                    Console.WriteLine("18 print method in Printer class completed.");
                    printedReceipts.Add(fifo);
                    listViewQueue.Items.RemoveAt(listViewQueue.Items[0].Index);
                    Console.WriteLine("19 fifo added to printedReceipts " + fifo.Sku);
                }
            }
        }
        private void pictureBoxView_Click(object sender, EventArgs e)
        {
            
            if (this.Height == compact_size.Height)
            {
                fullView();
            }
            else
            {
                compactView();
            }
            setLocation();
        }
        private void pictureBoxExpandLeft_Click(object sender, EventArgs e)
        {
            if (this.Width == compact_size.Width)
            {
                expandLeft();
            }
            else
            {
                fullView();
            }
            setLocation();
        }
        private void setStationsList(string[] stationsList)
        {
            comboBoxStation.Items.Clear();
            foreach (string station in stationsList)
            {
                comboBoxStation.Items.Add(station);
            }
            comboBoxStation.Items.Add("Mr. Leija Babinc");
        }
        private string getConfiguredStation()
        {
            if(comboBoxStation.SelectedIndex == -1)
            {
                return "all";
            }
            else
            {
                return comboBoxStation.Items[comboBoxStation.SelectedIndex].ToString();
            }
        }
        private string getPrinterName()
        {
            return textBoxPrinterName.Text;
        }
        private void setPrinterName(string name)
        {
            p.setPrinterName(name);
            textBoxPrinterName.Text = name;
            MsgTypes.printme(MsgTypes.msg_success, "printer set: " + name, this);
        }
        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            setPrinterName(getPrinterName());
        }
        private void buttonPullReceipts_Click(object sender, EventArgs e)
        {
            searchRMAReceiptsAction();
        }
        private void buttonPullPreReceipts_Click(object sender, EventArgs e)
        {
            searchRMAPreReceiptsAction();
        }
        private string get_rma()
        {
            return textBoxRMA.Text;
        }
        private string get_rma_2()
        {
            return textBoxRMA2.Text;
        }
        private void textBoxPrinterName_TextChanged(object sender, EventArgs e)
        {
            listViewQueue.Items.Clear();
        }
        private void comboBoxStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewQueue.Items.Clear();
            setSelection(comboBoxStation.Text);
        }
        #endregion

        #region Logic
        /// <summary>
        /// Gets all selected rows in dataReceiptsView datagrid.
        /// </summary>
        /// <returns>A list of Objects (Receipt or PreReceipts) containing data from the selected dataReceiptsView datagridView.</returns>
        private List<Object> getSelectedPrints()
        {
            Receipt receipt;
            List<Object> re_list = new List<Object>();
            PreReceipts prereceipt;
            List<Object> pre_list = new List<Object>();
            string lt ="";
            foreach(DataGridViewRow row in dataReceiptsView.SelectedRows)
            {
                Console.WriteLine("checking type: " + row.Cells[6].Value.ToString());
                Console.WriteLine("row count: " + row.Cells.Count);

                if(row.Cells.Count == 9)
                {
                    prereceipt = new PreReceipts();
                    prereceipt.Id = Int32.Parse(row.Cells[0].Value.ToString());
                    prereceipt.OrderNumber = row.Cells[1].Value.ToString();
                    prereceipt.TrackingNumber = row.Cells[2].Value.ToString();
                    prereceipt.Pallets = Int32.Parse(row.Cells[3].Value.ToString());
                    prereceipt.Boxes = Int32.Parse(row.Cells[4].Value.ToString());
                    prereceipt.CreatedOn = row.Cells[5].Value.ToString();
                    prereceipt.Employee = row.Cells[6].Value.ToString();
                    prereceipt.Channel = row.Cells[7].Value.ToString();
                    prereceipt.Item = Int32.Parse(row.Cells[8].Value.ToString());
                    pre_list.Add(prereceipt);
                    lt += row.Cells[0].ToString();
                }
                else
                {
                    receipt = new Receipt();
                    receipt.Tote = row.Cells[0].Value.ToString();
                    receipt.Sku = row.Cells[1].Value.ToString();
                    receipt.Qty = Int32.Parse(row.Cells[2].Value.ToString());
                    receipt.RMANumber = row.Cells[3].Value.ToString();
                    receipt.channel = row.Cells[4].Value.ToString();
                    receipt.station = row.Cells[5].Value.ToString();
                    receipt.employee = row.Cells[6].Value.ToString();
                    receipt.COO = row.Cells[7].Value.ToString();
                    receipt.disposition = row.Cells[8].Value.ToString();
                    receipt.scanTime = row.Cells[10].Value.ToString();
                    receipt.SerialNumber = row.Cells[11].Value.ToString();
                    receipt.Id = Int32.Parse(row.Cells[12].Value.ToString());
                    re_list.Add(receipt);
                    lt += row.Cells[12].ToString();
                }
            }   
            MsgTypes.printme(MsgTypes.msg_success, "list: " + lt,this);
            Console.WriteLine("list: " + lt);

            if (pre_list.Count > 0 )
            {
                return pre_list;
            }
            else
            {
                return re_list;
            }
        }
        /// <summary>
        /// Initializes dataReceiptsView as Receipt viewer and populates all receipts
        /// found for RMA provided in textBoxRMA.
        /// </summary>
        private void searchRMAReceiptsAction()
        {
            List<string[]> receiptedData = dysonData.getRMAReceipts(get_rma());
            if (receiptedData.Count > 0)
            {
                //init datagrid    
                init_receiptDatagridView();
                foreach (string[] item in receiptedData)
                {
                    dataReceiptsView.Rows.Insert(0, item);
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "there is no record of sn = " + get_rma() + ", at receiving", this);
            }
        }
        /// <summary>
        /// Initializes dataReceiptsView as PreReceipt viewer and populates all prereceipts
        /// found for RMa provided in textBoxRMA.
        /// </summary>
        private void searchRMAPreReceiptsAction()
        {
            List<string[]> receiptedData = dysonData.getRMAPreReceipts(get_rma());
            if (receiptedData.Count > 0)
            {
                init_prereceiptDataGridView();
                foreach (string[] item in receiptedData)
                {
                    dataReceiptsView.Rows.Insert(0, item);
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "there is no record of sn = " + get_rma() + ", at prereceiving", this);
            }
        }
        /// <summary>
        /// Stops the automatic printing job (if active) and dequeues all items queued in listViewQueue.
        /// Sends one print task per dequeued item. When done, reactivates automatic priting jobs.
        /// </summary>
        /// <param name="rma"></param>
        private void ManualPrint_Receipts(string rma)
        {
            timer1.Enabled = false;
            List<Receipt> list = dysonData.getRMAReceipts(rma,true);
            Console.WriteLine("2 list of receipts obtained: " + list.Count + " recepits pulled.");

            if (list.Count > 0)
            {
                addAllReceipts(list);
                popAllQueue();  // --> Change: from popOldestQueue to popAllQueue()
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "there are no receipts done for rma " + rma, this);
            }
            Console.WriteLine("9 completing ManualPrint_Receipts.");
            textBoxRMA2.Clear();
            timer1.Enabled = true;
        }
        /// <summary>
        /// Stops the automatic printing job (if active) and dequeues all items queued in listViewQueue.
        /// Sends one print task per dequeued item. When done, reactivates automatic priting jobs.
        /// </summary>
        /// <param name="rma"></param>
        private void ManualPrint_PreReceipts(string rma)
        {
            timer1.Enabled = false;
            List<PreReceipts> list = dysonData.getRMAPreReceipts(rma, true);
            
            if (list.Count > 0)
            {
                PreReceipts p = new PreReceipts();
                addAllReceipts(new List<Object> { list[0] });
                popOldestQueue();
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "there are no prereceipts done for rma " + rma , this);
            }
            textBoxRMA2.Clear();
            timer1.Enabled = true;
            
        }
        /// <summary>
        /// Calls the dequeuing function one time per each item queued in the listViewQueue.
        /// Efectively creating all pending print tasks.
        /// </summary>
        private void popAllQueue()
        {
            foreach(ListViewItem item in listViewQueue.Items)
            {
                popOldestQueue();
            }
        }
        /// <summary>
        /// Picks the oldest item inserted in listViewQueue and creates its print task, dequeuing the item.
        /// </summary>
        /// <returns></returns>
        private string popOldestQueue()
        {
            string oldestItem;
            if (listViewQueue.Items.Count > 0)
            {
                oldestItem = listViewQueue.Items[0].Text;
                Console.WriteLine("5 oldestItem: " + oldestItem);

                //Pre Receiving station is selected
               if(getSelectedStation().Contains("Pre Receiving") ||
                    getSelectedStation().Contains("Leija"))
                {
                    Console.WriteLine("6 Error Popping from PreReceiving Station");
                    PreReceipts r = new PreReceipts();
                    foreach(PreReceipts item in prereceiptList)
                    {
                        if(item.Id.ToString() == oldestItem.ToString())
                        {
                            r = item;
                        }
                    }
                    if(r.Id != 0) 
                    {
                        for(int i = 1; i <= r.Item; i++)
                        {
                            p.printTallyLabel(r,i);
                            if(i != r.Item)
                            {
                                addAllReceipts(new List<PreReceipts>(){r});
                            }
                            Console.WriteLine("print sent: " + r.ToString());
                        }
                    }
                }

               //Receiving station is selected
                else
                {
                    Console.WriteLine("6 Popping from Receiving Station");
                    Receipt r = receiptList.Find(x => x.Id.ToString() == oldestItem);
                    Console.WriteLine("7 after search in lists, found receipt: " + r.ToString());
                    if (r != null)
                    {
                        Console.WriteLine("8 calling print with receipt: " + r.ToString());
                        p.printUnitLabel(r);
                        Console.WriteLine("8.1 print sent: " + r.ToString(), this);
                    }
                    else
                    {
                        Console.WriteLine("7.2 could not find receipt: " + listViewQueue.Items[0].Text);
                    }
                }

                Console.WriteLine("8 completing pop returning string: " + oldestItem);
                return oldestItem;
            }
            return null;
        }
        /// <summary>
        /// Adds the provided Receipt item to the listViewQueue.
        /// </summary>
        /// <param name="receipt"></param>
        private void addReceiptToPrintQueue(Receipt receipt)
        {
            if (re_initialList.Find(x => x.Id == receipt.Id) == null)
                listViewQueue.Items.Add(receipt.Id.ToString());
        }
        /// <summary>
        /// Adds the provided PreReceipt item to the listViewQueue.
        /// </summary>
        /// <param name="prereceipt"></param>
        private void addPreReceiptToPrintQueue(PreReceipts prereceipt)
        {
            if (pre_initialList.Find(x => x.Id == prereceipt.Id) == null)
                listViewQueue.Items.Add(prereceipt.Id.ToString());
        }
        /// <summary>
        /// Receives a list of objects (Receipts or PreReceipts) and adds all contained items
        /// to listViewQueue.
        /// </summary>
        /// <param name="list"></param>
        private void addAllReceipts(List<Object> list)
        {
            if (IsReceiptList(list))
            {
                foreach(Receipt r in list)
                {
                    receiptList.Add(r);
                    listViewQueue.Items.Add(r.Id.ToString());
                }
            }
            else
            {
                foreach (PreReceipts r in list)
                {
                    prereceiptList.Add(r);
                    Console.WriteLine("adding to prereceiptlist: " + r.ToString());
                    //QUEUE 1
                    listViewQueue.Items.Add(r.Id.ToString());
                }
                Console.WriteLine("total preceipts in list:" + prereceiptList.Count);
                Console.WriteLine("receipts in list:");
                foreach(PreReceipts r in prereceiptList)
                {
                    Console.WriteLine("--- " + r.ToString());
                }
            }
        }
        /// <summary>
        /// Receives a List of PreReceipts and adds all contained items
        /// to listViewQueue.
        /// </summary>
        /// <param name="list"></param>
        private void addAllReceipts(List<PreReceipts> list)
        {   
            foreach (PreReceipts r in list)
            {
                prereceiptList.Add(r);

                listViewQueue.Items.Add(r.Id.ToString());
            }
        }
        /// <summary>
        /// Receives a List of Receipts and adds all contained items
        /// to listViewQueue.
        /// </summary>
        /// <param name="list"></param>
        private void addAllReceipts(List<Receipt> list)
        {
            Console.WriteLine("3 adding receipts to receiptList and listViewQueue");
            foreach (Receipt r in list)
            {
                receiptList.Add(r);
                listViewQueue.Items.Add(r.Id.ToString());
                Console.WriteLine("4 receipt " + r.ToString() + " added");
            }
        }
        /// <summary>
        /// Checks if the provided List of objects contains Receipts or PreReceipts.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>True if the list contains Receipts items, False otherwise.</returns>
        private bool IsReceiptList(List<object> list)
        {
            try
            {
                Object firstItem = list[0];
                if (((PreReceipts)firstItem).identifier == "pre")
                    return false;
                return true;
            }catch(System.InvalidCastException ex)
            {   
                return true; 
            }
        }
        /// <summary>
        /// Compares the given Receipt item with a List of Receipts and checks if the
        /// Receipt is contained in the List.
        /// </summary>
        /// <param name="receipt"></param>
        /// <param name="list"></param>
        /// <returns>True if the Receipt is contained in the List, False otherwise.</returns>
        private bool listContainsReceipt(Receipt receipt, List<Receipt> list)
        {
            foreach(Receipt item in list)
            {
                if(item.Id == receipt.Id)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Compares the given Receipt item with a LisView and checks if the
        /// Receipt is contained in the ListView.
        /// </summary>
        /// <param name="receipt"></param>
        /// <param name="listview"></param>
        /// <returns>True if the Receipt is contained in the ListView, False otherwise.</returns>
        private bool listContainsReceipt(Receipt receipt, ListView listview)
        {
            foreach (ListViewItem item in listview.Items)
            {
                string receiptId = item.Text.Split(' ')[0];
                if (receiptId == receipt.Id.ToString())
                    return true;
            }
            return false;
        }
        /// <summary>
        ///  Compares the given PreReceipt item with a List of PreReceipts and checks if the
        ///  PreReceipt is contained in the list.
        /// </summary>
        /// <param name="prereceipt"></param>
        /// <param name="list"></param>
        /// <returns>True if the PreReceipt is found in the list, False otherwise.</returns>
        private bool listContainsPreReceipts(PreReceipts prereceipt, List<PreReceipts> list)
        {
            foreach (PreReceipts item in list)
            {
                if (item.Id == prereceipt.Id)
                    return true;
            }
            return false;
        }
        /// <summary>
        ///  Compares the given PreReceipt item with a ListView and checks if the
        ///  PreReceipt is contained in the ListView.
        /// </summary>
        /// <param name="prereceipt"></param>
        /// <param name="listview"></param>
        /// <returns>True if the PreReceipt is found in the ListView.</returns>
        private bool listContainsPreReceipts(PreReceipts prereceipt,ListView listview)
        {
            foreach (ListViewItem item in listview.Items)
            {
                string receiptId = item.Text.Split(' ')[0];
                if (receiptId == prereceipt.Id.ToString())
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls all records (prereceipts or receipts) matching the given workstation configured 
        /// in the UI. Records pulled and not added to listViewReceipts will be added to the listView.
        /// </summary>
        private void updateReceipts()
        {
            List<Receipt> list_re = new List<Receipt>();
            List<PreReceipts> list_pre = new List<PreReceipts>();
            //Getting new data window
            string station = getConfiguredStation();
            if (station == "all")
            {
                if(station.Contains("Pre Receiving") || station.Contains("Leija"))
                {
                    Console.WriteLine("getting prereceipts with station");
                    list_pre = dysonData.getPreReceiptsWindow();
                }
                else
                {
                    list_re = dysonData.getReceiptsWindow();
                }
            }
            else
            {
                if (station.Contains("Pre Receiving") || station.Contains("Leija"))
                {
                    Console.WriteLine("getting prereceipts with station");
                    list_pre = dysonData.getPreReceiptsWindow(station);
                }
                else
                {
                    list_re = dysonData.getReceiptsWindow(station);
                }
            }
            //Clearing current data from memory buffers
            listViewReceipts.Items.Clear();
            receiptList.Clear();
            prereceiptList.Clear();

            //Updating memory lists of receipts and prereceipts
            if (station.Contains("Pre Receiving") || station.Contains("Leija"))
            {
                foreach (PreReceipts prereceipt in list_pre)
                {
                    prereceiptList.Add(prereceipt);
                    listViewReceipts.Items.Add(prereceipt.Id + " " + prereceipt.OrderNumber);
                }
                updateListWithList(list_pre);
            }
            else
            {
                foreach (Receipt receipt in list_re)
                {
                    receiptList.Add(receipt);
                    listViewReceipts.Items.Add(receipt.Id + " " + receipt.Sku);
                }
                updateListWithList(list_re);
            }
            labelLastUpdate.Text = "Last update: " + DateTime.Now;
        }
        /// <summary>
        /// Updates global variable holding all receipts adding a batch of receipts.
        /// </summary>
        /// <param name="batch"></param>
        private void updateListWithList(List<Receipt> batch)
        {
            foreach (Receipt receipt in batch)
            {
                if (!(fullReceiptListCollected.Any(item => item.Id == receipt.Id) ))
                    fullReceiptListCollected.Add(receipt);
            }
            
        }
        /// <summary>
        /// Updates global variable holding all prereceipts adding a batch of prereceipts.
        /// </summary>
        /// <param name="batch"></param>
        private void updateListWithList(List<PreReceipts> batch)
        {
            foreach (PreReceipts prereceipt in batch)
            {
                if (!(fullPreReceiptListCollected.Any(item => item.Id == prereceipt.Id)))
                    fullPreReceiptListCollected.Add(prereceipt);
            }

        }
        /// <summary>
        /// Sets a global variable holding the name of the configured workstation.
        /// </summary>
        /// <param name="selection"></param>
        private void setSelection(string selection)
        {
            this.selection = selection;
            comboBoxStation.SelectedIndex = comboBoxStation.FindStringExact(selection);
            MsgTypes.printme(MsgTypes.msg_success, "print source: " + getSelection(), this);
        }
        /// <summary>
        /// Activates a listViewReceipts item with text matching the provided string selection.
        /// </summary>
        /// <param name="selection"></param>
        private void highlightSelection(string selection)
        {
            if(selection != null)
            {
                var item = listViewReceipts.FindItemWithText(selection);
                if (item != null)
                    item.Selected = true;
            }
        }
        /// <summary>
        /// Handles get function of global variable selection.
        /// </summary>
        /// <returns></returns>
        private string getSelection()
        {
            return this.selection;
        }
        /// <summary>
        /// Reads the selection set on comboBoxStation and returns its value.
        /// </summary>
        /// <returns></returns>
        private string getSelectedStation()
        {
            return comboBoxStation.Text;
        }
        /// <summary>
        /// Receives a station name and sets the index of comboBoxStation to the item
        /// that matches the its text to the name provided.
        /// </summary>
        /// <param name="name"></param>
        private void setSelectedStation(string name)
        {
            comboBoxStation.SelectedIndex = comboBoxStation.FindString(name);
        }
        #endregion

        #region Cosmetics
        /// <summary>
        /// Sets location of the UI when form finishes loading.
        /// </summary>
        private void setLocation()
        {
            if (Taskbar.Position.ToString() == "Bottom")
            {
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - (int)(this.Width * 1.01),
                                          (int)(Taskbar.CurrentBounds.Y - this.Height * 1.05));
            }
            else
            {

            }
        }
        /// <summary>
        /// Shows the hidden fields available in UI.
        /// </summary>
        private void expandLeft()
        {
            listViewReceipts.Visible = true;
            listViewQueue.Visible = true;
            labelLastUpdate.Visible = true;
            prompt.Visible = true;

            labelCollected.Visible = true;
            labelQueued.Visible = true;
            labelLoss.Visible = true;
            checkBoxAutomatic.Visible = true;

            this.Size = expand_left;
            buttonManualPop.Visible = true;
        }
        /// <summary>
        /// Changes shape of UI to display compact view.
        /// </summary>
        private void compactView()
        {
            listViewReceipts.Visible = false;
            listViewQueue.Visible = false;
            labelLastUpdate.Visible = false;
            prompt.Visible = false;

            labelCollected.Visible = false;
            labelQueued.Visible = false;
            labelLoss.Visible = false;
            checkBoxAutomatic.Visible = false;

            this.Size = compact_size;
            buttonManualPop.Visible = false;
        }
        /// <summary>
        /// Changes shape of UI to show all fields in form.
        /// </summary>
        private void fullView()
        {
            listViewReceipts.Visible = true;
            listViewQueue.Visible = true;
            labelLastUpdate.Visible = true;
            prompt.Visible = true;

            labelCollected.Visible = true;
            labelQueued.Visible = true;
            labelLoss.Visible = true;
            checkBoxAutomatic.Visible = true;

            this.Size = full_size;
            buttonManualPop.Visible = true;
        }
        #endregion


    }
}
