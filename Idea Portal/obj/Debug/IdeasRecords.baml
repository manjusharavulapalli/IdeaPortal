   M S B A M L   `   `   `  ����  Idea Portal    Idea_Portal.IdeasRecords   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  IdeasRecords��5   	   $��520.064��6   $��720.876��6/    � WindowStyle$
 None=�6X    � 	Resources 5       �� 
TargetType   
LinkButton �� Orientation � Cursor  RequiredFieldLabel �� 
TargetType �� Property �� Value	 �� 
StartPoint
 �� EndPoint � Color � Offset��%o  &	        &	     �� 5   
   " ��6   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��	Underline{�6   $
 Hand��68   
����  ��� 5	      #��z��6#   5
      �� 5      $��ID��63   $y�	Collapsed=�6=   ��6   �� *ideaid+6V   5      5      �� 5   
   " ��6+   .�5      ��  � ��$ 12(�5   0   5      �� 5       � ��$ Lucida Calligraphy)�5   @   5      �� 5       � �� 5      �� 5      $		 0,0&�6*   $	
 1,1&�6;   .��5      � $ Purple��6'   $
 0.25Q�66   � 5      $
 Blue��6'   $	 1.0Q�64   5      5      5       5"      .��5#      � $��0,-3,0,3q�6   .+�5$   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DgIdeas��5$      $
��Left=�6$   $��1q�6?      AutoGenerateColumns .  $��
10,254,0,0q�6o   $	��Top=�6�   $	��248��6�   $	��683��6�      SelectionMode$ Single=�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�   $��Center=�6�      
IsReadOnly .  5%      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        �� 5&      "  6   .�5'      ��  � ��
 ��  �63   �� 5(       � ��$ 40��6/   �� 5)       � ��$ Center=�6C   5*      5+         Columns 5,      4  .System.Windows.Controls.DataGridTemplateColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ Idea Id��6)      CellTemplate 5.      �� 5/      .R�52      ��  ��Name$ BtnIdeaInfo��6%   -   5        ��52   :   �� *ideaid+53      55      57      0  *System.Windows.Controls.DataGridTextColumn  59      $ 
Idea Title��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Title+6U     5:      $ Student Name��6%    6;   �� *Name+6V     5;      $ Course Name��6%    6:   �� *Course+6W     5<      $ Status��6%    65   �� *Status+6R     5=      $ Pending With��6%    6;   �� *PendingWith+6]     5>      $ 
Created On��6%    69   �� *	CreatedOn+6Y   5@      �� 5A   
   -   5         ��Name$ ImageReports��5A      $
��Left=�6&   $	��176��6A   $	��Top=�6N   $	��693��6f   $��0,33,0,0q�6r   $��UniformToFill=�6�   �� 5B   
   -   5         ��Name$ lblwish��5B      #��[ 6!   $
��Left=�6N   $��	384,0,0,0q�6i   $	��Top=�6|   $	��325��6�   $��33��6�   $��18(�6�   �� 5C   
   -   5         ��Name$ 	TxtSearch��5C      $
��Left=�6%   $��23��6@   $��
66,217,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��136��6�    � ToolTip$ Enter Idea Id��6�   �� 5D   
   -   5        $ 	BtnSearch��5D      $��Search��6$   $
��Left=�65   $��207,218,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5E   
   -   5        $ 	lblIdeaid��5E      $��Idea Id��6#   $
��Left=�65   $��
10,214,0,0q�6P   $	��Top=�6d   $��51��6|   �� 5G   
   -	   5        $ BtnBack��5G      $
��Back��6"   $
 Back��62   $
��Left=�6A   $��4,5,0,0q�6\   $	��Top=�6m   $��48��6�   $��26��6�   ��5H      �� 5I      .R�5J      � .+�5K      A� ��5L      �� 5M   "    �� ImageSource$ Resources/Back.jpg��6-   5O      5P      5Q      5S      5T      5U      