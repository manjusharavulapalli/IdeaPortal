   M S B A M L   `   `   `  ����  Idea Portal     Idea_Portal.IdeaGeneration   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  IdeaCreationWindow��5   	    � Title$ IdeaGeneration��5   	   $��583.737��6    $��747.195��61    � WindowStyle$
 None=�6d    � 	Resources 5         RequiredFieldLabel �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint	 � Color
 � Offset �� Orientation��%"  &	        �� 5   
   " ��6+   .�5      ��  � ��$ 12(�5   0   5	      �� 5
       � ��$ Lucida Calligraphy)�5   @   5      �� 5       � �� 5      �� 5      $	 0,0&�6*   $	 1,1&�6;   .��5      � $	 Purple��6'   $

 0.25Q�66   � 5      $
	 Blue��6'   $	
 1.0Q�64   5      5      �� 5       � �� 5      �� 5      .R�5      �� $ 
Horizontal=�6%   .+�5      �� ��6(   �� �� 5      $��*��6(   
���  ��5      5      5      5       5!      5"      .��5#      � $��0,7,2,4q�6    � RowDefinitions 5'   
   �� 5(      $	��198 �6   �� 5)      $	��281 �6   �� 5*      $	��141 �6   .+�5,   
   �� -   5         ��Name$ Gr_ProcessDesc��5,      
���  ��$��Idea Description��6<   $��0��6V   $��	4,37,10,9q�6c   ���	#FFD5E5DA.��5-      � $��2,0,-2,2q�6    5.      �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   �� 51      $	��38* �6$    � ColumnDefinitions 53      �� 54      $
��151* �6'   66   �� 55      $
��568* �6'   66   .+�57      �� -   5         ��Name$ lblIdeaTitle��57      $��
Idea Title��6.   #��[  6C   $
��Left=�6o   $��4,10,0,0q�6�   $	��Top=�6�   $	��107��6�   $��26��6�   $��Lucida Calligraphy)�6�   �� 58      -   5         ��Name$ TxtTitle��58      $��1��6,   $
��Left=�6<   $��36��6W    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��558��6�   $��0,3,0,0q�6�   �� 59      -   5        $ lblIdeaDescription��59      #��[  64   $��Idea Description��6`   $
��Left=�6{   $��3,10,0,0q�6�   $��1��6�   $	��Top=�6�   $��26��6�   $	��126��6�   �� 5:      -   5        $ TxtDesc��5:      $��1��6+   $
��Left=�6;   $��49��6V   $��1��6b   $
 Wrap=�6o   $	��Top=�6�   $	��558��6�    �� AcceptsReturn . $��0,5,0,0q�6�   �� 5;      -   5        $ lblcategory��5;      #��[  6-   $��Category��6Y   $
��Left=�6l   $��2��6�   $	��Top=�6�   $	��108��6�   $��25��6�   $��1,0,0,0q�6�   �� 5<      -   5         ��Name$ CmbCategory��5<      $��1��60   $
��Left=�6@   $��2,5,0,0q�6[   $��2��6l   $	��Top=�6y   $	��185��6�   $��22��6�   .@�5=      ��  �� 
IsSelected . .��65   Improvement6B   �� 5>      .��6#   
Automation6/   �� 5?      .��6#   Others6+   5@      5A      5C      �� 5D   
   $��Proposed Idea��6   
���  ��$
��Left=�6<   $��4,5,0,0q�6W   $��1��6h   $	��Top=�6u   $	��337��6�   $	��728��6�   $��2��6�   .��5E      � $��0,0,0,0q�6    5F      �� 5G      $	��68* �6$   63   �� 5H      $	��72* �6$   63   �� 5I      $	��49* �6$   63   �� 5J      $
��123* �6$   64    5L      �� 5M      $	��29* �6'   65   �� 5N      -	   5         ��Name$ lblCurrentProcess��5N   '   $
��112* �6B   6Q   .+�5P      �� $��Current Process��6   #��[  62   $
��Left=�6^   $��	-3,24,0,0q�6y   $	��Top=�6�   $��26��6�   $	��126��6�   �� 5Q      -
   5        $ TxtCurrentProcess��5Q      $��1��65   $
��Left=�6E   $��61��6`   $
 Wrap=�6l   $	��Top=�6�   $	��563��6�    . 6�   �� 5R      -   5        $ lblproposedsolution��5R      #��[  65   $��Proposed Solution��6a   $
��Left=�6}   $��1,22,0,0q�6�   $��1��6�   $	��Top=�6�   $��26��6�   $	��122��6�   �� 5S      -   5        $ TxtProposedSolution��5S      $��1��67   $
��Left=�6G   $��63��6b   $��1��6n   $
 Wrap=�6{   $	��Top=�6�   $	��563��6�   �� 5T      -   5        $ 
lblBenfits��5T      #��[  6,   $��Benfits��6X   $
��Left=�6j   $��4,10,0,0q�6�   $��2��6�   $	��Top=�6�   $	��106��6�   $��26��6�   �� 5U      -   5        $ 
TxtBenfits��5U      $��1��6.   $
��Left=�6>   $��38��6Y   $��2��6e   $
 Wrap=�6r   $	��Top=�6�   $	��563��6�    . 6�   �� 5V      -   5        $ lblotherinfo��5V      #��[  6.   $��Other Informations��6Z   $��	2,10,10,0q�6w   $��3��6�   $	��Top=�6�   $��26��6�   �� 5W      -   5        $ TxtOtherInformations��5W      $��1��68   $
��Left=�6H   $��59��6c   $��3��6o   $
 Wrap=�6|   $	��Top=�6�   $	��563��6�   5X      5Z      �� 5[   
   -   5         ��Name$ BtnSubmitIdea��5[      $��Submit��6(   $
��Left=�69   $��
623,18,0,0q�6T   $��2��6h   $	��Top=�6u   $	��102��6�   $��29��6�   6�   �� 5\   
   -   5        $ LblWish��5\      $
��Left=�6"   $��	296,2,0,0q�6=   $	��Top=�6P   $	��403��6h   $��50��6t   $��Lucida Calligraphy)�6�   $��18(�6�   ��5]      �� 5^      $	 0,0&�6&   $	 1,1&�67   .��5_      � $	 Purple��6#   $

 0.25Q�62   � 5`      $
	 Blue��6#   $	
 1.0Q�60   5a      5c      �� 5d   
   -   5        $ TxtFilePath��5d      $
��Left=�6'   $��23��6B   $��	161,7,0,0q�6N   $��2��6a   $
 Wrap=�6n   $	��Top=�6�   $	��321��6�   �� 5e   
   $��Supported Documents��6   #��[  6/   $
��Left=�6[   $��6,4,0,0q�6v   $��2��6�   $	��Top=�6�   $	��148��6�   $��24��6�   �� 5f   
   -   5        $ 	BtnUpload��5f      $��Upload��6$   $
��Left=�65   $��	487,7,0,0q�6P   $��2��6c   $	��Top=�6p   $��49��6�   $��22��6�   �� 5g   
   -   5        $ BtnBack��5g      $
��Back��6"    � ToolTip$
 Back��62   $
��Left=�6A   $��10,0,0,0q�6\   $	��Top=�6n   $��47��6�   $��26��6�   ��5h      �� 5i      .R�5j      � .+�5k      A� ��5l      �� 5m   "    �� ImageSource$ Resources/Back.jpg��6-   5o      5p      5q      5s      5t      5u      