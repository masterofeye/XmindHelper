using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using XMindHelper.Helper;
using XMindHelper.HighLevelHelper;


namespace XMindHelper
{
   /// <summary>
   /// Interaktionslogik für MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
       public MainWindow()
       {
           InitializeComponent();

           ZipFile.ExtractToDirectory(@"C:\Projekte\XMindHelper\Beispiel\Hauptknoten.xmind", @"C:\Projekte\XMindHelper\Beispiel\extracted\");

           XElement x = null;
           using (var reader = XmlReader.Create(@"C:\Projekte\XMindHelper\Beispiel\extracted\content.xml"))
           {

              XDocument doc = XDocument.Load(reader);
              XMap_Content xml = XMap_Content.ParseXmlNode(doc.Root);
              XNamespace ns = "urn:xmind:xmap:xmlns:content:2.0";
              x = XMap_Content.CreateXmlNode(ns, xml);
              var target = doc.Root.Elements();

              ModificationRequest request = new ModificationRequest("Hallo Welt", 12345, "Hier könnte dein text stehen", new List<Statement>() { new Statement("symbol-question", "GS4") }, new List<Measure>() { new Measure("symbol-question", "GS4") });
             




              XElement el = Topic.CreateXmlNode(ns,  request.CreateMR());

              XElement elasd =  x.Descendants(ns + Constants.TITLE).Where(e => e.Value == "asd").FirstOrDefault();
              elasd.Parent.Parent.Add(el);

              XElement Hauptknoten = x.Descendants(ns + Constants.TITLE).Where(e => e.Value == "Hauptknoten").FirstOrDefault();
              Topic t = Topic.ParseXmlNode(Hauptknoten.Parent);
              t.Boundaries = new Boundaries();

              Boundary bound = new Boundary(t.ID, "(1,1)");
              t.Boundaries.AddBoundary(bound);

              //var target2 = doc.Root.Descendants(ns + "title").Where(e => e.Value == "BR213IC-GC-HL_MY17");
              //XElement = target2.FirstOrDefault().Parent;

              XElement ell = Topic.CreateXmlNode(ns,t);
              Hauptknoten.Parent.ReplaceWith(ell);

           }
           x.Save(@"C:\Projekte\XMindHelper\Beispiel\extracted\content.xml");
           File.Delete(@"C:\Projekte\XMindHelper\Beispiel\Hauptknoten2.xmind");
           ZipFile.CreateFromDirectory(@"C:\Projekte\XMindHelper\Beispiel\extracted\" , @"C:\Projekte\XMindHelper\Beispiel\Hauptknoten2.xmind");
           Directory.Delete(@"C:\Projekte\XMindHelper\Beispiel\extracted\",true);

           //yourResult.Save(@"C:\Users\Master\Desktop\content2.xml");
       }

       private void Button_Click(object sender, RoutedEventArgs e)
       {
          GridStellungnehmer.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

          int gridChildrenCount = GridStellungnehmer.Children.Count;
          XMindHelper.ListItem item = new XMindHelper.ListItem();
          Grid.SetRow(item, gridChildrenCount - 1);
          Grid.SetColumn(item, 0);
          GridStellungnehmer.Children.Add(item);

       }
   }
}
