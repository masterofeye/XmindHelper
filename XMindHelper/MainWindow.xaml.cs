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

         //Füllt die ComboBoxen mit leben 
         LoadProjects();
         LoadSamplePhases();
         LoadSWRelease();
      }

      /// <summary>
      /// Ladet die Projekte aus der Konfiguration und fügt sie der GUI hinzu
      /// </summary>
      private void LoadProjects()
      { 
         var list = Properties.Settings.Default.Projects.Cast<string>().ToList();
         if(list.Count > 0)
         {
            foreach(var project in list)
            {
               CBProject.Items.Add(project);
            }
         }
      }

      /// <summary>
      /// Ladet die Sample Phases aus der Konfiguration und fügt sie der GUI hinzu
      /// </summary>
      private void LoadSamplePhases()
      {
         var list = Properties.Settings.Default.SamplePhase.Cast<string>().ToList();
         if (list.Count > 0)
         {
            foreach (var project in list)
            {
               CBSamplePhase.Items.Add(project);
            }
         }
      }

      /// <summary>
      /// Ladet die Software Releases aus der Konfiguration und fügt sie der GUI hinzu
      /// </summary>
      private void LoadSWRelease()
      {
         var list = Properties.Settings.Default.SWRelease.Cast<string>().ToList();
         if (list.Count > 0)
         {
            foreach (var project in list)
            {
               CBSWRelease.Items.Add(project);
            }
         }
      }


      private void Button_AddStellungnehmer(object sender, RoutedEventArgs e)
      {
         //Neue Zeile einfügen in das Grid ayout
         GridStellungnehmer.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

         int gridChildrenCount = GridStellungnehmer.RowDefinitions.Count;
         //Listitem erstellen
         XMindHelper.ListItem item = new XMindHelper.ListItem(gridChildrenCount - 1);
         //und in das Grid einfügen
         Grid.SetRow(item, gridChildrenCount - 1);
         Grid.SetColumn(item, 0);
         GridStellungnehmer.Children.Add(item);

      }

      private void Button_DeleteStellungnehmer(object sender, RoutedEventArgs e)
      {
         int gridChildrenCount = GridStellungnehmer.RowDefinitions.Count;
         if (gridChildrenCount > 1)
         {
            GridStellungnehmer.RowDefinitions.RemoveAt(gridChildrenCount - 1);
            GridStellungnehmer.Children.RemoveAt(gridChildrenCount);
         }
      }

      private void Button_AddCCB(object sender, RoutedEventArgs e)
      {
         //Neue Zeile einfügen in das Grid ayout
         GridCCB.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

         int gridChildrenCount = GridCCB.RowDefinitions.Count;
         //Listitem erstellen
         XMindHelper.ListItem item = new XMindHelper.ListItem(gridChildrenCount - 1);
         //und in das Grid einfügen
         Grid.SetRow(item, gridChildrenCount - 1);
         Grid.SetColumn(item, 0);
         GridCCB.Children.Add(item);
      }

      private void Button_DeleteCCB(object sender, RoutedEventArgs e)
      {
         int gridChildrenCount = GridCCB.RowDefinitions.Count;
         if (gridChildrenCount > 1)
         {
            GridCCB.RowDefinitions.RemoveAt(gridChildrenCount - 1);
            GridCCB.Children.RemoveAt(gridChildrenCount);
         }
      }

      private void Button_AddMessure(object sender, RoutedEventArgs e)
      {
         //Neue Zeile einfügen in das Grid ayout
         GridMeasure.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

         int gridChildrenCount = GridMeasure.RowDefinitions.Count;
         //Listitem erstellen
         XMindHelper.ListItem item = new XMindHelper.ListItem(gridChildrenCount - 1);
         //und in das Grid einfügen
         Grid.SetRow(item, gridChildrenCount - 1);
         Grid.SetColumn(item, 0);
         GridMeasure.Children.Add(item);
      }

      private void Button_DeleteMessure(object sender, RoutedEventArgs e)
      {
         int gridChildrenCount = GridMeasure.RowDefinitions.Count;
         if (gridChildrenCount > 1)
         {
            GridMeasure.RowDefinitions.RemoveAt(gridChildrenCount - 1);
            GridMeasure.Children.RemoveAt(gridChildrenCount);
         }
      }

      private void Button_CreateEntry(object sender, RoutedEventArgs e)
      {
         String project, mrNumber, titel, samplePhase, swRelease;
         List<Statement> statementList = null;
         List<String> CBBList = null;
         List<Measure> messureList = null;

         if (String.IsNullOrEmpty(CBProject.SelectedItem as String))
         {
            MessageBox.Show("Please choose a Project");
            return;
         }
         else
         {
            project = CBProject.SelectedItem as String;
         }

         if (String.IsNullOrEmpty(TBMRNumber.Text))
         {
            MessageBox.Show("MR Number is missing");
            return;
         }
         else
         {
            mrNumber = TBMRNumber.Text;
         }

         if (String.IsNullOrEmpty(TBTitel.Text))
         {
            MessageBox.Show("Titel is missing");
            return;
         }
         else 
         {
            titel = TBTitel.Text;
         }

         if (String.IsNullOrEmpty(CBSamplePhase.SelectedItem as String))
         {
            MessageBox.Show("Please choose a Sample Phase");
            return;
         }
         else
         {
            samplePhase = CBSamplePhase.SelectedItem as String;
         }

         if (String.IsNullOrEmpty(CBSWRelease.SelectedItem as String))
         {
            MessageBox.Show("Please choose a SW Release");
            return;
         }
         else
         {
            swRelease = CBSWRelease.SelectedItem as String;
         }

         if (GridStellungnehmer.RowDefinitions.Count <= 1)
         {
            MessageBox.Show("Stellungnehmer fehlen");
            return;
         }
         else
         {
            statementList = new List<Statement>();
            for (int i = 2; i < GridStellungnehmer.Children.Count; i++)
            {
               statementList.Add(new Statement("symbol-question",(GridStellungnehmer.Children[i] as ListItem).GetName()));
            }
         }

         if (GridCCB.RowDefinitions.Count > 2)
         {
            CBBList = new List<string>();
            for (int i = 2; i < GridCCB.Children.Count; i++)
            {
               CBBList.Add((GridCCB.Children[i] as ListItem).GetName());
            }
         }

         if (GridMeasure.RowDefinitions.Count > 2)  
         {
            messureList = new List<Measure>();
            for (int i = 2; i < GridMeasure.Children.Count; i++)
            
               messureList.Add(new Measure("symbol-question",(GridMeasure.Children[i] as ListItem).GetName()));
         }
         ZipFile.ExtractToDirectory(@"C:\Projekte\XMindHelper\Beispiel\ICBWMDL.xmind", @"C:\Projekte\XMindHelper\Beispiel\extracted\");

         XElement x = null;
         using (var reader = XmlReader.Create(@"C:\Projekte\XMindHelper\Beispiel\extracted\content.xml"))
         {

            XDocument doc = XDocument.Load(reader);
            XMap_Content xml = XMap_Content.ParseXmlNode(doc.Root);
            XNamespace ns = "urn:xmind:xmap:xmlns:content:2.0";
            x = XMap_Content.CreateXmlNode(ns, xml);
            var target = doc.Root.Elements();



            //Create MR 
            ModificationRequest request = new ModificationRequest(titel, UInt16.Parse(mrNumber), "", statementList, messureList);

            //MR Muss nun in den aktuellen Baum eingehangen werden
            XElement projectNode = x.Descendants(ns + Constants.TITLE).Where(ee => ee.Value == project).FirstOrDefault();
            if (projectNode == null)
            {
               //Knoten erzeugen der das Projekt beinhaltet, weil es bisher noch nicht benutzt wurde
               Topic projectTopic = new Topic(project);
               //MR Knoten erzeugen um dem Projekt zuordnen
               projectTopic.AddSubTopicToAttached(request.CreateMR());
               //Implementierungsknoten suchen
               XElement implementNode = x.Descendants(ns + Constants.TITLE).Where(ee => ee.Value == "Implementierung").FirstOrDefault();
               Topic implement = Topic.ParseXmlNode(implementNode.Parent);
               //Project nun dem Knoten der Implementierung hinzufügen
               implement.AddSubTopicToAttached(projectTopic);
               //aktullen Implementierungsknoten mit dem neuen ersetzen
               implementNode.Parent.ReplaceWith(Topic.CreateXmlNode(ns, implement));
            }
            else
            {
               //Projekt ist schon vorhanden wir brauchen ihn nur in ein Topic zu parsen
               Topic projectTopic = Topic.ParseXmlNode(projectNode.Parent);
               //MR Knoten erzeungen und dem Projekt hinzufügen
               projectTopic.AddSubTopicToAttached(request.CreateMR());
               //Alten Projektknoten mit dem neuen ersetzen
               projectNode.Parent.ReplaceWith(Topic.CreateXmlNode(ns, projectTopic));
            }

         }
         x.Save(@"C:\Projekte\XMindHelper\Beispiel\extracted\content.xml");
         File.Delete(@"C:\Projekte\XMindHelper\Beispiel\ICBWMDL.xmind");
         ZipFile.CreateFromDirectory(@"C:\Projekte\XMindHelper\Beispiel\extracted\", @"C:\Projekte\XMindHelper\Beispiel\ICBWMDL.xmind");
         Directory.Delete(@"C:\Projekte\XMindHelper\Beispiel\extracted\", true);
      }
   }
}
