   M S B A M L   `   `   `  ����K  GComputerGraphics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ComputerGraphics.MVVM.ViewComputerGraphics.MVVM.View  5      1    +ComputerGraphics.MVVM.View.LectureSevenView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ComputerGraphics.MVVM.View     5        � 	Resources  5	         mouseOverColor �� Color �� 
TargetType  mouseOverStyle �� Triggers P� Property P� Value �� Property �� Value  VerticalSeparatorStyle �� Angle  MyGridBrushResource	 j� Viewport
 j� ViewportUnits j� TileMode L� Drawing � Brush � Geometry �� Rect��%$  &	        &	 #     7   &	 �     &	 �    �� 5
   
   $ 	#FF797979��61   �� 5   
   " ��6    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��8   63   5      5      �� 5   
   " ��5      .�5      ��  � ��$ 6,0,6,0q�6'   �� 5       �@�LayoutTransform 5      V� 5      ~�5      X� �� 5   "   $ 90Q�62   5      5      5       5!      L� 5#   
   $	 	0,0,10,10�63   $
 Absolute=�6H   $
 Tile=�6a    5$      I� 5%      ��5'      �  �	#99FFFFFF 5(      �� 5)   "   $ 0,0,1,1�64   5+      � 5,      + ��        �@B     �@B �� �    �� 	 �	#661414146M   � 5-      + ��        �    @B Ѡ� @B Ѡ�     	 �	#661414146M   5/      51      52      .��54      �  � ColumnDefinitions 55   
   �� 56      $	��400 �6   �� 57      $	��400 �6    � RowDefinitions 5:   
   �� 5;      $��10 �6   �� 5<      $��* �6   .+�5@   
   �� $��0��6   $��2��6$   $��	0,0,-30,0q�5A      $��Hidden=�5B      .��5C      �� $	��Top=�5D      .+�5F      �� $
��Left=�6   $��0��67   $��0��6D   $%��VYPĹŇANIE ROVINNÝCH OBLASTÍ��5G      $
��Bold"�67   $��20(�6I   ���	#FF4242426W   �� 5I      $
��Left=�6   $��0��5J      $��0��6!   $��	10,30,0,0q�5K      $����Oblasťou rozumieme množinu bodov, ktoré sú navzájom susedné. 

Oblasť zadaná svojimi vnútornými bodmi sa nazýva vnútorne definovaná. Všetky body  oblasti majú v tomto prípade zadanú hodnotu. Algoritmy, ktoré pracujú s takýmito oblasťami,  sa nazývajú vnútorne vypĺňajúce algoritmy.  
 
Oblasť zadaná hranicou sa nazýva hranične definovaná. Body, ktoré vytvárajú hranicu, majú  predpísanú hodnotu. Algoritmy, ktoré pracujú s takýmito oblasťami, sa nazývajú hranične  vypĺňajúce algoritmy.��5L      $
��Wrap=�5R      $��14(�5S      ���	#FF4242426"   9� 5V       9� 
IsExpanded$ False��6   $��0��5W      $��0��6    $��2��5X      
������ $��
FLOOD FILL��5Y   ,   ���	#FF424242$��16(�5Z   *   $
��Bold"�68    � Cursor$
 Hand��5[      .��5\      �� .+�5]      �� $
��Wrap=�6%   $��Normal"�5^      ���	#FF424242$��14(�5`      $����Ide o rekurzívny algoritmus a pracuje tak , že priradí bodom 4 - súvislej vnútorne definovanej oblasti hodnotu new value. 

Vstup: old_value, new_value, súradnice (x, y) vnútorného bodu oblasti, od ktorého sa má  začať vypĺňať.  

Postup: Pre vnútorný bod so súradnicami (x, y) zistíme, či sme ho ešte nevyšetrovali (preto  musí mať hodnotu old_value). Ak je to tak, hodnota sa zmení, a potom sa vyšetria jeho ďalšie  4 - susedné body.  
Dá sa modifikovať aj pre 8 - súvislé oblasti (budeme v rekurzii vyšetrovať 8 - susedov).  

Algoritmus sa dá použiť napr. na vykreslenie oblasti inou farbou.��5a      �� 5j      -   5         ��Name$ 	floodFill��5k   !   $��	Výpočet��5j   !   $��80��5l   !   $��30��6,   
������ $��Bottom=�5m   !   $��Right=�6<   $��10q�5n   !   ���	#FF424242$��Normal"�5p   !   $��12(�5q   !   ��5s      �� 5t   "    �� EndPoint$ 0.9,1&�66    �� 
StartPoint$ 0.4,0&�6G   .��5u   &   �  � Color$ 	#FF82B2FF��63   � 5v   &   $ 	#FF9491FF��63    � Offset$ 1Q�6E   5w   #   5y      5z      5{      9� 5~      $ False��6   $��0��5      $��0��6    $��2��5�      
������ $��	SEED FILL��5�   ,   ���	#FF424242$��16(�5�   *   $
��Bold"�68   $
 Hand��5�      .��5�      �� .+�5�      �� $
��Wrap=�6%   $��Normal"�5�      ���	#FF424242$��14(�5�      $ Arrow��5�      $����Tento algoritmus vyplňuje rekurzívnym spôsobom. Bod, od ktorého sa začína vyplňovať, sa  volá semienko. Ak semienko neleží na hranici a nebolo doteraz zafarbené, potom je zafarbené  a vyšetrujú sa ďalej jeho 4 - susedia.  

Je to rekurzívne riešenie – neefektívne. Každý vnútorný pixel je testovaný niekoľkokrát  potom, ako už bol zafarbený. Pomer počtu rekurzívnych volaní k počtu skutočných zafarbení  je 4:1. Každé vyvolanie procedúry je spojené s operáciou čítania z obrazovej pamäti.  

Vstup:
vypln_farba, hran_farba, súradnice (x, y) vnútorného bodu oblasti, od ktorého sa má  začať vypĺňať.  

Postup:
Začína sa s bodom (x, y) a pre susedné body sa zisťuje, či majú farbu hranice. Ak nie,  potom sú zafarbené farbou výplne. Takto sa spracujú všetky body oblasti až po hranicu.  ��5�      �� 5�      -   5        $ seedFill��5�   !   $��	Výpočet��5�   !   $��80��5�   !   $��30��6,   
������ $��Bottom=�5�   !   $��Right=�6<   $��10q�5�   !   ���	#FF424242$��Normal"�5�   !   $��12(�5�   !   ��5�      �� 5�   "   $ 0.9,1&�66   $ 0.4,0&�6G   .��5�   &   � $ 	#FF82B2FF��63   � 5�   &   $ 	#FF9491FF��63   $ 1Q�6E   5�   #   5�      5�      5�      9� 5�      $ False��6   $��0��5�      $��0��6    $��2��5�      
������ $��SCAN-LINE SEED FILL��5�   ,   ���	#FF424242$��16(�5�   *   $
��Bold"�68   $
 Hand��5�      .��5�      �� .+�5�      �� $
��Wrap=�6%   $��Normal"�5�      ���	#FF424242$��14(�5�      $ Arrow��5�      $����Metóda, ktorá znižuje počet prístupov do obrazovej pamäti, sa volá riadkové semienkové  vypĺňanie - SEED_LINE_FILL. Namiesto rekurzie sa použije malý zásobník, do ktorého sa  uloží niekoľko súradníc vnútorných bodov vyplňovanej oblasti. 

Metóda sa dá urýchliť tak, že do zásobníka ukladáme namiesto jednotlivých bodov informácie  o voľných úsekoch nájdených v krokoch 2d a 2e algoritmu. Voľné úseky však musíme hľadať nielen v intervale (XLeft – XRight), ale nad a pod nakreslenou úsečkou smerom doľava  a doprava až k hranici oblasti. Potom je možné vynechať v algoritme krok 2b a zmenšiť počet  čítaní z obrazovej pamäti. ��5�      �� 5�      -   5        $ seedLineFill��5�   !   $��	Výpočet��5�       $��80��5�   !   $��30��6,   
������ $��Bottom=�5�   !   $��Right=�6<   $��10q�5�   !   ���	#FF424242$��Normal"�5�   !   $��12(�5�   !   ��5�      �� 5�   "   $ 0.9,1&�66   $ 0.4,0&�6G   .��5�   &   � $ 	#FF82B2FF��63   � 5�   &   $ 	#FF9491FF��63   $ 1Q�6E   5�   #   5�      5�      5�      9� 5�      $ False��6   $��0��5�      $��0��6    $��2��5�      
������ $��SKENOVACÍ ALGORITMUS��5�   ,   ���	#FF424242$��16(�5�   *   $
��Bold"�68   $
 Hand��5�      .��5�      �� .+�5�      �� $
��Wrap=�6%   $��Normal"�5�      ���	#FF424242$��14(�5�      $ Arrow��5�      $����Algoritmus rozkladu odstraňuje mnohú ťažkosti doterajších postupov. 

Máme zobrazený mnohouholník s jedným skenovacím riadkom. Potrebujeme určiť, ktoré obrazové body sa nachádzajú vo vnútri mnohouholníka pre tento skenovací riadok a definovať im príslušnú hodnotu vnútra oblasti. Tento proces opakujeme pre každý skenovací riadok prechádzajúci daným mnohouholníkom. Takýmto postupom dostaneme úplný rastrový rozklad mnohouholníka. 

Algoritmus: 
1. Nájdeme všetky priesečníky skenovacej priamky so všetkými stranami mnohouholníka.  
2. Usporiadame priesečníky podľa x - ovej súradnice.  
3. Zafarbíme všetky body, ktoré sa nachádzajú vždy medzi dvojicami za sebou  usporiadaných priesečníkov.��5�      �� 5�      -   5        $ scanner��5�   !   $��Ukážka��5�   !   $��80��5�   !   $��30��6,   
������ $��Bottom=�5�   !   $��Right=�6<   $��10q�5�   !   ���	#FF424242$��Normal"�5�   !   $��12(�5�   !   ��5�      �� 5�   "   $ 0.9,1&�66   $ 0.4,0&�6G   .��5�   &   � $ 	#FF82B2FF��63   � 5�   &   $ 	#FF9491FF��63   $ 1Q�6E   5�   #   5�      5�      5�      9� 5�      $ False��6   $��0��5�      $��0��6    $��2��5�      
������ $��KOHERENTNOSŤ STRÁN��5�   ,   ���	#FF424242$��16(�5   *   $
��Bold"�68   $
 Hand��5     .��5     �� .+�5     �� $
��Wrap=�6%   $��Normal"�5     ���	#FF424242$��14(�5     $ Arrow��5     $����V predchádzajúcom algoritme sa najprv nájdu priesečníky skenovacej priamky so všetkými  stranami mnohouholníka. Tento výpočet je pomalý, pretože treba každú stranu porovnať so  skenovacou priamkou.  

Pri hľadaní priesečníkov so skenovacou priamkou však nemusíme s ňou porovnávať všetky  strany. Ak strana pretína i - ty skenovací riadok, potom obvykle pretína aj (i + 1) - vý  skenovací riadok. Pri prechode od jedného riadku k druhému môžeme vypočítať novú x - ovú  súradnicu priesečníka so skenovacím riadkom takto: 
��5     �� 5     $
��Wrap=�6%   $��Normal"�5     $��Italic$�5     ���	#FF424242$��14(�5     $#��x ( i + 1) = x ( i ) + 1 / m,��5     �� 5     $
��Wrap=�6%   $��Normal"�5     ���	#FF424242$��14(�5     $]��Wkde m je tangens uhla strany s osou x – smernica priamky, na  ktorej úsečka leží
��5     �� 5     $
��Wrap=�6%   $��Normal"�5     $��Italic$�5     ���	#FF424242$��14(�5     $8��2m = dy / dx, dy = 1, m = 1 / dx, potom dx = 1 / m
��5      �� 5!     -   5        $ coherent��5"  !   $��Ukážka��5!  !   $��80��5#  !   $��30��6,   
������ $��Bottom=�5$  !   $��Right=�6<   $��10q�5%  !   ���	#FF424242$��Normal"�5'  !   $��12(�5(  !   ��5*     �� 5+  "   $ 0.9,1&�66   $ 0.4,0&�6G   .��5,  &   � $ 	#FF82B2FF��63   � 5-  &   $ 	#FF9491FF��63   $ 1Q�6E   5.  #   50     52     53     54     55     �� 57  
   -   5         ��Name$ refresh��58     $��/Images/return.png��57     $��30��59     $��1��5:     $��1��6    $��Right=�5;     $	��Top=�5<     $��0,0,40,0q�5=     $y�Hidden=�5>     5?     �� 5A  
   -   5         ��Name$ canvas��5B     $��1��5A     $��0��6!   $��0,50,0,0q�5C     
�������$	��320��5E     $	��320��6   $
 Hand��6*   $y�Hidden=�5F     .+�5G     � -   5         �Name$
 grid��5G     5H     �� 5J  
   -	   5         ��Name$ 	showStack��5K     $��1��5J     $��1��6!   $��Bottom=�6.   $��Center=�6I   $��0,0,0,90q�5L     $��2q�5M     
�������$y�Hidden=�5O     ._�5P     �� -
   5        $ canvasQueue��5Q     $��30��5R     $	��200��6   
�������5T     5U     �� 5W  
   -   5         ��Name$ textAddPixel��5X     $��1��5W     $��1��6$   $y�Hidden=�5Y     $��Center=�5Z     $��Center=�6/   $��Spustite vypĺňanie��5[     ���	#FF424242$��Normal"�5]     $��14(�5^     $��	0,270,0,0q�5_      �� Padding$ 0,10,0,0q�5`     �� 5b  
   -   5        $ 
fillButton��5c     $��Vyplniť��5b     $	��100��5d     $��35��6   
������ $��1��5e     $��1��6!   $��Bottom=�5f     ���	#FF424242$��Normal"�5h     $��14(�5i     $��0,0,0,40q�5j     $y�Hidden=�5k     ��5m     �� 5n     $ 0.9,1&�6&   $ 0.4,0&�67   .��5o     � $ 	#FF82B2FF��6#   � 5p     $ 	#FF9491FF��6#   $ 1Q�65   5q     5s     �� 5u  
   -   5        $ coherentImg1��5v     $��1��5u     $��1��6    $	��370��6-   $y�Hidden=�5w     $��30,0,0,0q�5x     ��5y     �� 5z      �� DecodePixelWidth$	 500��6     �� 	UriSource$  /Images/coherent.png?�5{     5}     �� 5  
   -   5        $ coherentImg2��5�     $��1��5     $��1��6    $	��360��6-   $y�Hidden=�5�     $��30,0,0,0q�5�     ��5�     �� 5�     $	 500��6   $  /Images/coherent2.png?�5�     5�     �� 5�  
   -   5        $ 	nextImage��5�     $��/Images/next.png��5�     $y�Hidden=�5�     $��1��5�     $��1��6    $��30��5�     $��Bottom=�5�     $��Center=�6+   $��0,0,0,40q�5�     5�     �� 5�  
   -   5        $ 
scannerImg��5�     $��1��5�     $��1��6    $	��300��6-   $y�Hidden=�5�     ��5�     �� 5�     $
 1000��6   $  /Images/scanner.png?�5�     5�     5�     5�     