   M S B A M L   `   `   `  ����  Idea Portal    Idea_Portal.AproverForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  AproverForm��5   	   $��593.042��6   $��731.936��6.    � 	Resources 5       �� 
TargetType   
LinkButton �� Orientation � Cursor �� Triggers P� Property P� Value �� Property	 �� Value  Familystyle
 �� 
TargetType  RequiredFieldLabel �� 
StartPoint �� EndPoint � Color � Offset��%�  &	        &	     &	 �    �� 5   
   " ��6   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��	UnderLine{�6   $
 Hand��68   
����  ��� 5	      #��z��6#   5
      5       5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
	 �����6B   5      5      �� 5   
   "
 ��6$   .�5      ��  � ��$	 Lucida Calligraphy)�5   @   5      5      �� 5   
   "
 ��6+   .�5      ��  � ��$	 12(�5   0   5      �� 5       � ��$	 Lucida Calligraphy)�5    @   5!      �� 5"       � ��	 5#      �� 5%      $	 0,0&�6*   $	 1,1&�6;   .��5&      � $ Purple��6'   $
 0.25Q�66   � 5'      $
 Blue��6'   $	 1.0Q�64   5(      5*      5+      5,      .��5-      � .+�5.   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DgRecords��5.      $
��Left=�6&   $��Center=�6A   $��
10,266,0,0q�6e      AutoGenerateColumns .  $	��Top=�6�   $	��288��6�   $	��692��6�      
IsReadOnly .  5/      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%x   '        �� 50      "
  6   .�51      ��  � ��
	 ��  �63   �� 52       � ��$	 30��6/   53      54         Columns 55      4  .System.Windows.Controls.DataGridTemplateColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ Idea Id��6)      CellTemplate 57      �� 58      .R�5;      ��  ��Name$ BtnIdeaInfo��6%   -   5        ��5;   :   �� *ideaid+5<      5>      5@      0  *System.Windows.Controls.DataGridTextColumn  5B      $ 
Idea Title��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Title+6U     5C      $ Student Name��6%    6;   �� *Name+6V     5D      $ Course Name��6%    6:   �� *Course+6W     5E      $ Status��6%    65   �� *Status+6R     5F      $ Pending With��6%    6;   �� *PendingWith+6]     5G      $ 
Created On��6%    69   �� *	CreatedOn+6Y   5I      �� 5J   
   -   5         ��Name$ 
StackLinks��5J      $
��Left=�6)   $��41��6D   $��377,225,0,0q�6P   $ 
Horizontal=�6e   $	��Top=�6~   $	��274��6�    J� RenderTransformOrigin$ 0.515,0.585&�6�   .+�5K      �� -   5        $ BtnPendingIdeas��5K      $��Ideas To Aprove��6.   #��[  6H   #��[ 6o   $��	5,11,0,10q�6�   $��86��6�   $��Vijaya)�6�   $��15(�6�   �� 5L      -   5        $ BtnTotalIdeas��5L      $��List Of Ideas��6,   #��[  6D   #��[ 6k   $��5,10,0,0q�6�   $��70��6�   $��Vijaya)�6�   $��15(�6�   �� 5M      -   5        $ BtncourseIdeas��5M      $��Course Ideas��6-   #��[  6D   #��[ 6k   $��5,10,0,0q�6�   $��72��6�   $��Vijaya)�6�   $��15(�6�   5O      �� 5P   
   -   5         ��Name$ 	ImgAprove��5P      $
��Left=�6#   $	��193��6>   $	��Top=�6K   $	��690��6c   $��UniformToFill=�6o   $��0,34,0,0q�6�   �� 5Q   
   -	   5         ��Name$ 	TxtSearch��5Q      $
��Left=�6%   $��23��6@   $��
67,235,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��114��6�   �� 5R   
   -
   5        $ 	BtnSearch��5R      $��Search��6$   $
��Left=�65   $��186,235,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5S   
   -   5         ��Name$ 	lblsearch��5S      $��Idea ID��6#   $
��Left=�65   $��
15,235,0,0q�6P   $	��Top=�6d   $��47��6|   �� 5T   
   -   5        $ lblwish��5T      #��[ 6!   $��Label��6M   $
��Left=�6]   $��
377,10,0,0q�6x   $	��Top=�6�   $	��274��6�   $��18(�6�   5U      5V      