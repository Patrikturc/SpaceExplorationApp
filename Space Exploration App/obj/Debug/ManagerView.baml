   M S B A M L   `   `   `  ����P  LSpace Exploration App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Space_Exploration_AppSpace_Exploration_App  5   	   '    !Space_Exploration_App.ManagerView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Space_Exploration_App     5   	     � Title$  ManagerView��5   	   $��389.661��6   $��634.418��6.   ��5	      �� 5
   
    �� ImageSource$ 2 blue stars.jpg��6   .��5      � .+�5   
   �� -   5         ��Name$ btnListRegistered��5      $��List registered users��6,   $
��Left=�6L   $��
277,52,0,0q�6g   $	��Top=�6{   $	��112��6�   
�������
����������	#7F0000006�   �� 5   
   -   5         ��Name$ 
txtDisplay��5      $
��Left=�6&   $	��272��6A   $��
277,77,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��339��6�   
���   ����	#CCFFFFFF6�   �� 5   
   -   5         ��Name$ cmbMemberToRemove��5      $
��Left=�6.   $��	10,97,0,0q�6I   $	��Top=�6\   $	��120��6t   �� 5   
   $��Select a member to remove��6   $
��Left=�64   $��	10,66,0,0q�6O   $	��Top=�6b   
�������6z   �� 5   
   -   5        $ 	btnRemove��5      $��Remove member��6$   $
��Left=�6<   $��
146,97,0,0q�6W   $	��Top=�6k   $	��120��6�   $��23��6�   ���	#7F000000
�������
�������6�   �� 5   
   -   5        $ btnAddMember��5      $��
Add Member��6'   $
��Left=�6<   $��
533,50,0,0q�6W   $	��Top=�6k   $��83��6�   $��22��6�   
�������
����������	#7F0000006�   �� 5   
   $��Hello dear Manager.��6   $
��Left=�6.   $��	10,10,0,0q�6I   $	��Top=�6\   
�������6t   �� 5   
   -   5        $ cmbSelectType��5      $
��Left=�6*   $��
408,50,0,0q�6E   $	��Top=�6Y   $	��120��6q   �� 5   
   -   5        $ 
btnRefresh��5      $��Update��6%   $
��Left=�66   $��
541,10,0,0q�6Q   $	��Top=�6e   $��75��6}   ���	#7F000000
�������
�������6�   �� 5   
   -   5        $ cmbModifyMember��5      $
��Left=�6,   $��	8,181,0,0q�6G   $	��Top=�6Z   $	��120��6r    J� RenderTransformOrigin$ 
0.48,1.392&�6~   �� 5   
   -	   5        $ 	btnModify��5      $��Modify Member��6$   $
��Left=�6<   $��
10,267,0,0q�6W   $	��Top=�6k   $	��120��6�   $��22��6�   
�������
����������	#7F0000006�   �� 5   
   $!��Insert new last name please��6   $
��Left=�66   $��	8,208,0,0q�6Q   $	��Top=�6d   
�������
���   �6�   �� 5   
   $'��!Select member to modify last name��6   $
��Left=�6<   $��	8,150,0,0q�6W   $	��Top=�6j   
�������
���   �6�   �� 5   
   -
   5        $ txtNewLastName��5      $
��Left=�6*   $��23��6E   $��
10,239,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5   
   $&�� Finished all your work? Please -��6   $
��Left=�6;   $��
170,10,0,0q�6V   $	��Top=�6j   
�������6�   �� 5   
   -   5        $ 	btnLogOut��5      $��Log Out��6$   $
��Left=�66   $��
345,10,0,0q�6Q   $	��Top=�6e   $��75��6}   $��26��6�   ���	#7F000000
�������
�������6�   5      5      