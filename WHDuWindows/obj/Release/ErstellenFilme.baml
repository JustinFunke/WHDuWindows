   M S B A M L   `   `   `  ???? F  BWHDuWindows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WHDuWindowsWHDuWindows       WHDuWindows.ErstellenFilme   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WHDuWindows     -     ? Title$  ErstellenBuecher??$	??400??$	??600?? ? 
ResizeMode$ NoResize=? ? WindowStyle$
 None=? ? WindowState$ Normal=? ? WindowStartupLocation$ CenterScreen=?.??? -   ???#696969 ? RowDefinitions ?? $??80 ??? ?? $??50 ?.+?A? -    A?Name$ cmdClosnHinzufuegen??$??0?????#dc143c$??20??$??20?? ? Cursor$
 Hand?? ? ToolTip$ Close??$??	0,10,10,0q?$??Right=?$	??Top=??? -   	 ??Name$	 lblAnzeigeWHD??$??0??$??Hinzufügen Film??$??Century Gothic)?$??40(?$??Center=?$	??Top=????#efebdc$??0,20,0,0q??? $??1??$??30,15q?.+?? 
 ? ColumnDefinitions
 ?? ?? .+??? $??0??.+??? $??Titel:??$??Century Gothic)?$??20(????	#FF00C0C0$??0,0,0,10q??? $??	Anbieter:??$??Century Gothic)?$??20(????	#FF00C0C0$
??0,10q??? $??Fertig Jahr:??$??Century Gothic)?$??20(????	#FF00C0C0$
??0,10q??? $??
Bewertung:??$??Century Gothic)?$??20(????	#FF00C0C0$??0,10,0,0q??? $??Von 1 bis 5??$??Century Gothic)?$??10(????#efebdc$??	0,-10,0,0q??? $??1??.+??? -    ??Name$ txtTitel??" ?? VerticalScrollBarVisibility$
 Auto=?$??20(?$??Century Gothic)?$??0q?$
??0,10q?$	??270??$??37??$??Center=??? -    ??Name$ cBoxAnbieter??$??20(?$??Century Gothic)?$??0q?$
??0,10q?$	??150??$??37??$??Center=??? -   $ txtDatum??$
 Auto=?$??20(?$??Century Gothic)?$??0q?$
??0,10q?$	??270??$??37??$??Center=?? 
 ?? ?? ?? ?? ?? .+??? -    ??Name$ Stern1??$??0?? ?? BitmapScalingMode$ HighQuality=?$??Right=??? -	   $ Stern2??$??1??$ HighQuality=?$??Right=??? -
   $ Stern3??$??2??$ HighQuality=?$??Right=??? -   $ Stern4??$??3??$ HighQuality=?$??Right=??? -   $ Stern5??$??4??$ HighQuality=?$??Right=??? $??2??$
??40,0q?.+??? -    ??Name$ cmdHinzufuegen??$??2??$??Century Gothic)?$??25(?$
??20,0q?$??Hinzufügen?????	#FF00C0C0$??3??#??? ??