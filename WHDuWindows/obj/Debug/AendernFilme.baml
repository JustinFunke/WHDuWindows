   M S B A M L   `   `   `  ????F  BWHDuWindows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WHDuWindowsWHDuWindows  5   	       WHDuWindows.AendernFilme   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WHDuWindows     5   	   -   5          ? Title$  AendernFilme??5   	   $	??400??6   $	??600??6+    ? 
ResizeMode$ NoResize=?67    ? WindowStyle$
 None=?6M    ? WindowState$ Normal=?6`    ? WindowStartupLocation$ CenterScreen=?6u   .??5	      ? -   5        ???#696969 ? RowDefinitions 5
   
   ?? 5      $??80 ?6   ?? 5      ?? 5      $??50 ?6   .+?5   
   A? -   5         A?Name$ cmdClosnHinzufuegen??5      $??0??6/   ???#dc143c$??20??6K   $??20??6W    ? Cursor$
 Hand??6b    ? ToolTip$ Close??6p   $??	0,10,10,0q?6?   $??Right=?6?   $	??Top=?6?   6  ?? 5   
   -   5        	 ??Name$	 lblAnzeigeWHD??5      $??0??6   $??Ändern Film??64   $??Century Gothic)?6J   $??40(?6f   $??Center=?6t   $	??Top=?6?   ???#efebdc$??0,20,0,0q?6?   ?? 5   
   $??1??6   $??30,15q?6"   .+?5      ? 
 ? ColumnDefinitions
 5      ?? 5      ?? 5      .+?5      ?? $??0??6   .+?5      ?? $??Titel:??6   $??Century Gothic)?6-   $??20(?6I   ???	#FF00C0C0$??0,0,0,10q?6n   ?? 5      $??	Anbieter:??6   $??Century Gothic)?60   $??20(?6L   ???	#FF00C0C0$
??0,10q?6q   ?? 5      $??Fertig Jahr:??6   $??Century Gothic)?63   $??20(?6O   ???	#FF00C0C0$
??0,10q?6t   ?? 5       $??
Bewertung:??6   $??Century Gothic)?61   $??20(?6M   ???	#FF00C0C0$??0,10,0,0q?6r   ?? 5!      $??Von 1 bis 5??6   $??Century Gothic)?62   $??10(?6N   ???#efebdc$??	0,-10,0,0q?6q   5"      ?? 5#      $??1??6   .+?5$      ?? -   5         ??Name$ txtTitel??5$      " ?? VerticalScrollBarVisibility$
 Auto=?60   $??20(?6S   $??Century Gothic)?6a   $??0q?6}   $
??0,10q?6?   $	??270??6?   $??37??6?   $??Center=?6?   ?? 5%      -   5         ??Name$ cBoxAnbieter??5%      $??20(?65   $??Century Gothic)?6C   $??0q?6_   $
??0,10q?6t   $	??150??6?   $??37??6?   $??Center=?6?   ?? 5&      -   5        $ txtDatum??5&      $
 Auto=?60   $??20(?6S   $??Century Gothic)?6a   $??0q?6}   $
??0,10q?6?   $	??270??6?   $??37??6?   $??Center=?6?   6?   ? 5'      
 5(      ?? 5)      ?? 5*      ?? 5+      ?? 5,      ?? 5-      .+?5/      ?? -   5         ??Name$ Stern1??5/       $??0??61    ?? BitmapScalingMode$ HighQuality=?6A   $??Right=?6o   6?   ?? 50      -	   5        $ Stern2??50       $??1??60   $ HighQuality=?6A   $??Right=?6o   6?   ?? 51      -
   5        $ Stern3??51       $??2??60   $ HighQuality=?6A   $??Right=?6o   6?   ?? 52      -   5        $ Stern4??52       $??3??60   $ HighQuality=?6A   $??Right=?6o   6?   ?? 53      -   5        $ Stern5??53       $??4??60   $ HighQuality=?6A   $??Right=?6o   6?   54      56      58      5<      ?? 5?   
   $??2??6   $
??40,0q?6"   .+?5@      ?? -   5         ??Name$ cmdHinzufuegen??5@      $??2??6-   $??Century Gothic)?6:   $??25(?6V   $
??20,0q?6d   $??Ändern??6r   ???	#FF00C0C0$??3??6?   #??? ??6?   6?   5A      5C      5D      