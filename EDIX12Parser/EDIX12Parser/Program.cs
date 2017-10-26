using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EDIX12Parser
{
    class Program
    {
        private static string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
        static string eventlog = string.Empty;
        static string syspath = System.Configuration.ConfigurationManager.AppSettings["EDI.RUTA"].ToString();
        static string eventerrorlog = string.Empty;

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("EDI FILE PARSER");
            Console.WriteLine("Main start");
            Task t = asyncMethod();
            t.ContinueWith((str) =>
            {
                Console.WriteLine(str.Status.ToString());
                Console.WriteLine("Main end");
            });
            writelog();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ReadKey();
        }
        public async static Task<string> asyncMethod()
        {
            setnewlogline("Iniciando modelo asyncrono de ejecucion");
            await Task.Run(() => processdata());
            setnewlogline("Terminando modelo asyncrono de ejecucion");
            return "finished";
        }
        static void processdata()
        {
            string datetoday = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                string[] filePaths = Directory.GetFiles(syspath, "*.EDI");

                if (filePaths.Length == 0)
                {
                    setnewlogline("No se encontraron archivos para procesar");
                }
                else
                {
                    setnewlogline("Procesando archivos en: " + syspath);


                    if (!Directory.Exists(syspath + @"\processed"))
                        Directory.CreateDirectory(syspath + @"\processed");

                    foreach (string file in filePaths)
                    {
                        setnewlogline("Procesando archivo" + file);

                        Console.BufferHeight = Int16.MaxValue - 1;
                        var reader = new StreamReader(file);
                        var message = reader.ReadToEnd();

                        char SegDelimiter = message[105];
                        char ElemDelimiter = message[103];

                        var segments = (from seg in message.Split(SegDelimiter).Select(x => x.Trim())
                                        where !String.IsNullOrEmpty(seg)
                                        select new models.Segment
                                        {
                                            SegID = seg.Substring(0, seg.IndexOf(ElemDelimiter)),
                                            Elements = seg.Split(ElemDelimiter).Skip(1).ToArray()
                                        }).ToList();

                        reader.Close();

                        var editype = segments.Find(x => x.SegID == "ST");
                        if (editype.Elements[0] == "830")
                        {
                            new803file(segments, file);
                            var newfile = syspath + @"\processed\" + Path.GetFileName(file);
                            File.Move(file, newfile);
                            setnewlogline("Archivo Procesado Exitosamente");
                        }
                        else if (editype.Elements[0] == "856")
                            new856file(segments);
                        else
                            setnewlogline("Tipo de archivo EDI: Formato Invalido, solo es posible processar archivos formato 830 y 856");
                    }
                }
            }
            catch (Exception ex)
            {
                setnewlogline(string.Format("Se produjo un error durante el proceso, mesage de error: {0}", ex.Message));
                writerrorlogline(string.Format("Error Trace: {0}", ex.Message), true);
                writerrorlogline(string.Format("Stack trace: {0}", sLogFormat, ex.StackTrace), true);
            }
        }
        static void new803file(List<models.Segment> segments, string filename)
        {
            setnewlogline("Tipo de archivo EDI: 830");
            var newgen = new models.EDI830.EDI830General_Information();
            var bfredi = segments.Find(x => x.SegID == "BFR");
            newgen.edifilename = filename;
            newgen.release_number = bfredi.Elements[2];
            newgen.schedule_horizon_from = bfredi.Elements[5];
            newgen.schedule_horizon_to = bfredi.Elements[6];
            newgen.issued_date = bfredi.Elements[7];
            newgen.idstatus = 0;
            var gen = new models.EDI830();
            var genid = gen.AddNew(newgen);

            var lines = segments.FindAll(x => x.SegID == "LIN");
            var linescount = lines.Count;
            var i = 0;

            var linesindex = new List<int>();
            foreach (models.Segment segment in segments)
            {
                segment.SID = i;
                if (segment.SegID == "LIN")
                {
                    linesindex.Add(i);
                }
                i += 1;
            }
            var endlines = segments.Find(x => x.SegID == "CTT").SID;


            for (var ln = 0; ln < linescount; ln++)
            {
                var seg = segments[linesindex[ln]];
                var linegenid = 0;
                var newln = new models.EDI830.EDI830Line_General(genid);
                newln.buyer_partnumber = seg.Elements[2];
                newln.purchase_order = seg.Elements[4];
                newln.process = "";
                for (var inline = linesindex[ln]; inline < endlines; inline++)
                {
                    var segln = segments[inline];

                    if (segln.SegID == "LIN")
                        continue;

                    if (segln.SegID == "UIT")
                    {
                        newln.unit = segln.Elements[0];
                        continue;
                    }
                    if (segln.SegID == "PID")
                    {
                        newln.product_description = segln.Elements[4];
                        continue;
                    }
                    if (segln.SegID == "ATH" && segln.Elements[0] == "FI")
                    {
                        newln.aut_date_fi = segln.Elements[1];
                        continue;
                    }
                    if (segln.SegID == "ATH" && segln.Elements[0] == "MT")
                    {
                        newln.aut_date_mt = segln.Elements[1];
                        continue;
                    }
                    if (segln.SegID == "FST")
                    {
                        if (linegenid == 0)
                        {
                            linegenid = newln.AddNew(newln);
                        }
                        var lndetail = new models.EDI830.EDI830Line_Detail(linegenid);
                        lndetail.quantity = int.Parse(segln.Elements[0]);
                        if (segln.Elements[1] == "C")
                        {
                            lndetail.timing = "Firm: Daily";
                        }
                        else
                            lndetail.timing = "Planning: Weekly Bucket (Monday through Sunday)";

                        lndetail.scheduled_date = segln.Elements[3];
                        lndetail.AddNew(lndetail);
                        continue;
                    }
                }
            }
        }
        static void new856file(IList<models.Segment> segments)
        {
            setnewlogline("Tipo de archivo EDI: 856");
        }
        static void setnewlogline(string txt)
        {
            string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            eventlog += sLogFormat + txt + "<br />" + Environment.NewLine;
            Console.WriteLine(txt);
        }
        static void writerrorlogline(string txt, bool errdetected)
        {
            string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            eventerrorlog += sLogFormat + txt + "<br />" + Environment.NewLine;
            Console.WriteLine(txt);
        }
        static void writelog()
        {
            if (!Directory.Exists(syspath + @"\log"))
                Directory.CreateDirectory(syspath + @"\log");

            string datetoday = DateTime.Now.ToString("yyyyMMdd");
            string logfimename = syspath + @"log\" + datetoday + ".txt";

            System.IO.FileStream fs1 = new System.IO.FileStream(logfimename, System.IO.FileMode.Append, System.IO.FileAccess.Write);


            System.IO.StreamWriter writer = new System.IO.StreamWriter(fs1);
            writer.WriteLine(eventlog);
            writer.Close();
        }
    }
}
