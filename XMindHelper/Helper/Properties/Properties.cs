using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMindHelper.Helper
{
   class Properties
   {
      private String _borderLineColor;

      public String BorderLineColor
      {
         get { return _borderLineColor; }
         set { _borderLineColor = value; }
      }

      private String _borderLineWidth;

      public String BorderLineWidth
      {
         get { return _borderLineWidth; }
         set { _borderLineWidth = value; }
      }
      private String _fontFamiliy;

      public String FontFamiliy
      {
         get { return _fontFamiliy; }
         set { _fontFamiliy = value; }
      }
      private String _fontSize;

      public String FontSize
      {
         get { return _fontSize; }
         set { _fontSize = value; }
      }
      private String _fontStyle;

      public String FontStyle
      {
         get { return _fontStyle; }
         set { _fontStyle = value; }
      }
      private String _color;

      public String Color
      {
         get { return _color; }
         set { _color = value; }
      }
      private String _fontWeight;

      public String FontWeight
      {
         get { return _fontWeight; }
         set { _fontWeight = value; }
      }
      private String _textDecoration;

      public String TextDecoration
      {
         get { return _textDecoration; }
         set { _textDecoration = value; }
      }
      private String _textTransform;

      public String TextTransform
      {
         get { return _textTransform; }
         set { _textTransform = value; }
      }
      private String _lineClass;

      public String LineClass
      {
         get { return _lineClass; }
         set { _lineClass = value; }
      }
      private String _lineColor;

      public String LineColor
      {
         get { return _lineColor; }
         set { _lineColor = value; }
      }

      private String _linePattern;

      public String LinePattern
      {
         get { return _linePattern; }
         set { _linePattern = value; }
      }

      private String _linetapered;

      public String Linetapered
      {
         get { return _linetapered; }
         set { _linetapered = value; }
      }

      private String _lineWidth;

      public String LineWidth
      {
         get { return _lineWidth; }
         set { _lineWidth = value; }
      }
      private String _shapeClass;

      public String ShapeClass
      {
         get { return _shapeClass; }
         set { _shapeClass = value; }
      }
      private String _fill;

      public String Fill
      {
         get { return _fill; }
         set { _fill = value; }
      }

      public static BoundaryProperties ParseXmlNode(XElement Node)
      {
         BoundaryProperties b = new BoundaryProperties();

         IEnumerable<XAttribute> attrCol = Node.Attributes();
         foreach (XAttribute item in attrCol)
         {
            switch (item.Name.LocalName)
            {
               case Constants.COLOR:
                  b.Color = item.Value;
                  break;
               case Constants.FONTFAMILIY:
                  b.FontFamiliy = item.Value;
                  break;
               case Constants.FONTSIZE:
                  b.FontSize = item.Value;
                  break;
               case Constants.FONTSYTLE:
                  b.FontStyle = item.Value;
                  break;
               case Constants.FONTWEIGHT:
                  b.FontWeight = item.Value;
                  break;
               case Constants.TEXTDECORATION:
                  b.TextDecoration = item.Value;
                  break;
               case Constants.SHAPECLASS:
                  b.ShapeClass = item.Value;
                  break;
               case Constants.FILL:
                  b.Fill = item.Value;
                  break;
               default:
                  break;
            }
         }
         return b;
      }

      public static XElement CreateXmlNode(XNamespace Ns, BoundaryProperties B)
      {
         XElement el = new XElement(Constants.BOUNDARYPROPERTIES);

         XNamespace nsFormat = "fo";
         XNamespace nsSVG = "svg";

         /*Font Attributes*/
         if (String.IsNullOrEmpty(B.FontFamiliy))
            el.Add(new XAttribute(nsFormat + Constants.FONTFAMILIY, B.FontFamiliy));
         if (String.IsNullOrEmpty(B.FontSize))
            el.Add(new XAttribute(nsFormat + Constants.FONTSIZE, B.FontSize));
         if (String.IsNullOrEmpty(B.FontStyle))
            el.Add(new XAttribute(nsFormat + Constants.FONTSYTLE, B.FontStyle));
         if (String.IsNullOrEmpty(B.FontWeight))
            el.Add(new XAttribute(nsFormat + Constants.FONTWEIGHT, B.FontWeight));
         if (String.IsNullOrEmpty(B.TextDecoration))
            el.Add(new XAttribute(nsFormat + Constants.FONTWEIGHT, B.TextDecoration));

         /*Line Attributes*/
         if (String.IsNullOrEmpty(B.LineColor))
            el.Add(new XAttribute(Constants.LINECOLOR, B.LineColor));
         if (String.IsNullOrEmpty(B.LinePattern))
            el.Add(new XAttribute(Constants.LINEPATTERN, B.LinePattern));
         if (String.IsNullOrEmpty(B.Linetapered))
            el.Add(new XAttribute(Constants.LINETAPERED, B.Linetapered));
         if (String.IsNullOrEmpty(B.LineWidth))
            el.Add(new XAttribute(Constants.LINEWIDHT, B.LineWidth));
         if (String.IsNullOrEmpty(B.LineClass))
            el.Add(new XAttribute(Constants.LINECLASS, B.LineClass));

         if (String.IsNullOrEmpty(B.ShapeClass))
            el.Add(new XAttribute(Constants.SHAPECLASS, B.ShapeClass));

         if (String.IsNullOrEmpty(B.Fill))
            el.Add(new XAttribute(nsSVG + Constants.FILL, B.Fill));

         return el;
      }
   }
}
