using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using System.Net;



namespace NFLInfoCenter.Classes
{
    class Printer
    {
        
        public string printerName { get; set; }

        private System.Drawing.Printing.PrintDocument printer;
        private System.Windows.Forms.Form commingFrom;
        
        private string burntPrinterName = "zebralocalprinter";

        private string hostname;
        private string stationName;

        private Receipt receipt;

        private PreReceipts prereceipt;

        public Printer(System.Windows.Forms.Form commingFrom, System.Drawing.Printing.PrintDocument printer)
        {
            this.printerName = burntPrinterName;
            //this.printerName = "zebrawifiprinter";

            this.commingFrom = commingFrom;

            this.printer = printer;

            this.printer.PrinterSettings.PrinterName = this.printerName;

            //printer.PrinterSettings.PrinterName = printerName;

            hostname = Dns.GetHostName();

            

        }
        
        public string get_sn() {
            try
            {
                if (receipt.IsSerialized())
                {
                    return receipt.SerialNumber;
                }
                else
                {
                    return "";
                }
            }catch(Exception e)
            {
                return "";
            }
        }
        public void setPrinterName(string name)
        {
            this.printerName = name;
            this.printer.PrinterSettings.PrinterName = this.printerName;
        }
        public void set_receipt(Receipt receipt)
        {
            this.receipt = receipt;
        }
        public void set_prereceipt(PreReceipts prereceipt)
        {
            this.prereceipt = prereceipt;
        }
  
        public void printUnitLabel(Receipt receipt)
        {
            if(receipt != null)
            {
                set_receipt(receipt);
                printer.DocumentName = "unit_label_" + receipt.Id.ToString();
                printer.Print();

            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "receipt is null: ", commingFrom);
            }
        }

        public void printTallyLabel(PreReceipts prereceipt,int item)
        {
            if (prereceipt != null)
            {
                set_prereceipt(prereceipt);
                printer.DocumentName = "tallyLabel_" + prereceipt.Id.ToString() + "_" + item;
                printer.Print();
            }
            else
            {
               
            }
        }

        public bool print(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            if (printer.DocumentName.Contains("tally"))
            {
                int item = Int32.Parse(printer.DocumentName.Split('_')[2].ToString());    
                printTallyLabelDocument(sender, e, item); 
            }
            else
            {
                printUnitLabelDocument(sender, e);
            }


            return true;
        }

        public void printTallyLabelDocument(object sender,System.Drawing.Printing.PrintPageEventArgs e,int item)
        {
            //Setting barcode creator
            BarcodeWriter bwriter = new BarcodeWriter();
            bwriter.Options.PureBarcode = true;
            bwriter.Format = BarcodeFormat.CODE_128;
            bwriter.Options.Height = 20;
            //Setting Font Brush and Pen
            int fontSize = 10;
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", fontSize, System.Drawing.FontStyle.Regular);
            System.Drawing.Font bold = new System.Drawing.Font("Arial", fontSize, System.Drawing.FontStyle.Bold);
            System.Drawing.Font bigFont = new System.Drawing.Font("Arial", fontSize*2, System.Drawing.FontStyle.Bold);

            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.Pen pen = new System.Drawing.Pen(brush);
            //e.Graphics.DrawRectangle(pen, new System.Drawing.Rectangle(0, 0, 400, 200));
            //Setting layout properties
            int spacer = 12;
            int leftmargin = 10;


            int x = leftmargin;
            int y = 0;
            e.Graphics.DrawString("DYSON" , bigFont, brush, new System.Drawing.Point(x, y));

            x = leftmargin;
            y += spacer*3;
            e.Graphics.DrawString("Tracking Number:", bold, brush, new System.Drawing.Point(x, y ));

            x = leftmargin;
            y += spacer ;
            e.Graphics.DrawString(prereceipt.TrackingNumber, printFont, brush, new System.Drawing.Point(x, y ));


            x = leftmargin;
            y += spacer*2;
            e.Graphics.DrawString("Channel:", bold, brush, new System.Drawing.Point(x, y ));
            x = 160;
            e.Graphics.DrawString("item " + item.ToString() + " of " + prereceipt.Item, bigFont, brush, new System.Drawing.Point(x, y ));
            
            x = leftmargin;
            y += spacer;
            e.Graphics.DrawString(prereceipt.Channel, printFont, brush, new System.Drawing.Point(x, y));

            x = leftmargin;
            y += spacer*2;
            e.Graphics.DrawString("Date:", bold, brush, new System.Drawing.Point(x, y ));
            x = leftmargin+50;
            e.Graphics.DrawString(prereceipt.CreatedOn, printFont, brush, new System.Drawing.Point(x, y ));



            x = leftmargin;
            y += spacer*2;
            e.Graphics.DrawString("RMA:", bold, brush, new System.Drawing.Point(x,y));
            x = leftmargin+50;
            e.Graphics.DrawString(prereceipt.OrderNumber, bigFont, brush, new System.Drawing.Point(x, y ));


           
            x = leftmargin+200;
            y += spacer*2+10;
            e.Graphics.DrawString(prereceipt.Employee, bold, brush, new System.Drawing.Point(x, y));

            
            x = leftmargin+20;
            e.Graphics.DrawImage(bwriter.Write(prereceipt.OrderNumber), new System.Drawing.Point(x - 20, y));
            //e.Graphics.DrawImage(sfbarcode.ToImage(sfbarcode.Size), new System.Drawing.Point(x - 20, y));

        }
        public void printUnitLabelDocument(object sentder, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //try
            //{
            //Setting barcode creator
            BarcodeWriter bwriter = new BarcodeWriter();
            bwriter.Options.PureBarcode = true;
            bwriter.Format = BarcodeFormat.CODE_128;
            bwriter.Options.Height = 20;
            //Setting Font Brush and Pen
            int fontSize = 7;
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", fontSize, System.Drawing.FontStyle.Regular);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.Pen pen = new System.Drawing.Pen(brush);
            e.Graphics.DrawRectangle(pen, new System.Drawing.Rectangle(0, 0, 300, 300));
            //Setting layout properties
            int spacer = 13;
            int leftmargin = 20;

            int x = leftmargin;
            int y = 0;
            e.Graphics.DrawString("Disposition: " + receipt.disposition, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)));
            x = 17;
            y += spacer * 2;
            e.Graphics.DrawImage(bwriter.Write(receipt.disposition), new System.Drawing.Point(x - 20, y));
            MsgTypes.printme(MsgTypes.msg_success, "dis im size: " + bwriter.Write(receipt.disposition).Size.ToString(), commingFrom);

            x = leftmargin;
            y += spacer;
            e.Graphics.DrawString("SKU : " + receipt.Sku, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)));
            e.Graphics.DrawString("Qty : " + receipt.Qty, printFont, brush, new System.Drawing.Point(x + 160, y + (spacer * 1)));


            x = leftmargin;
            y += spacer * 2;
            e.Graphics.DrawImage(bwriter.Write(receipt.Sku), new System.Drawing.Point(x - 10, y));
            e.Graphics.DrawImage(bwriter.Write(receipt.Qty.ToString()), new System.Drawing.Point(x - 10 + 140, y));



            x = leftmargin;
            y += spacer;
            e.Graphics.DrawString("RMA : " + receipt.RMANumber, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)));
            x = leftmargin;
            y += spacer * 2;
            e.Graphics.DrawImage(bwriter.Write(receipt.RMANumber), new System.Drawing.Point(x - 10, y));

            e.Graphics.DrawString("COO : " + receipt.COO, printFont, brush, new System.Drawing.Point(x + 160, y + (spacer * 1)));



            x = leftmargin;
            y += spacer;
            e.Graphics.DrawString("Tote : " + receipt.Tote, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)));
            x = 15;
            y += spacer * 2;
            e.Graphics.DrawImage(bwriter.Write(receipt.Tote), new System.Drawing.Point(x - 10 + 6, y));


            x = leftmargin;
            y += spacer;
            e.Graphics.DrawString("Channel : " + receipt.channel, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)));
            x = leftmargin;
            y += spacer * 2;
            e.Graphics.DrawImage(bwriter.Write(receipt.channel), new System.Drawing.Point(x - 10, y));


            string sn;
            if (receipt.IsSerialized())
            {
                sn = receipt.SerialNumber;
            }
            else
            {
                sn = "";
            }
            x = leftmargin;
            y += spacer;
            e.Graphics.DrawString("Serial Number : " + sn, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)));
            x = leftmargin;
            y += spacer * 2;
            if (receipt.IsSerialized())
                e.Graphics.DrawImage(bwriter.Write(sn), new System.Drawing.Point(x - 10, y));

            x = leftmargin;
            y += spacer * 2;
            e.Graphics.DrawString("Received by: " + receipt.employee, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)));

            x = leftmargin;
            y += spacer;
            e.Graphics.DrawString("Source: " + hostname, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)));
            if (receipt.HasStation())
                e.Graphics.DrawString(receipt.station, printFont, brush, new System.Drawing.Point(x + 110, y + (spacer * 2)));

            e.Graphics.DrawString("nfl tools", printFont, brush, new System.Drawing.Point(260, 285));

            e.Graphics.DrawString("ReceiptId: " + receipt.Id.ToString(), printFont, brush, new System.Drawing.Point(x, y + (spacer * 2)));
            
            System.Drawing.StringFormat sf = new System.Drawing.StringFormat();
            sf.Alignment = System.Drawing.StringAlignment.Near;
            sf.FormatFlags = System.Drawing.StringFormatFlags.DirectionVertical;


            x = 280;
            y = 0;
            e.Graphics.DrawString("© R.L. Jones Customhouse Brokers", printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)), sf);

            x = 265;
            y = 0;
            e.Graphics.DrawString("Date Scanned: " + receipt.scanTime, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)), sf);

            x = 250;
            y = 0;
            e.Graphics.DrawString("Date Printed: " + DateTime.Now, printFont, brush, new System.Drawing.Point(x, y + (spacer * 1)), sf);


            //}
            //catch(Exception ex)
            //{
            //    MsgTypes.printme(MsgTypes.msg_failure, "Could not complete print, receopt id: " + receipt.Id,commingFrom);
            //    Console.WriteLine(receipt.Id.ToString());
            //    return false;
            //}
        }

    }
}
