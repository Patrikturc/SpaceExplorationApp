   M S B A M L   `   `   `  ����P  LSpace Exploration App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Space_Exploration_AppSpace_Exploration_App  5   	   '    !Space_Exploration_App.VisitorView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Space_Exploration_App     5   	     � Title$  VisitorView��5   	   $��274.846��6   $��623.424��6.   ��5	      �� 5
   
    �� ImageSource$ exo2.jpg��6   .��5      � .+�5   
   �� $9��3Welcome to St Pete's Research facility application.��6   $
��Left=�6N   $��0,10,0,0q�6i   $	��Top=�6{   
���   �$
��Bold"�6�   ��6�   Z� 6�   �� 5   
   -   5         ��Name$ btnDisplayStars��5      $%��Display discovered Star systems��6*   $
��Left=�6T   $��	10,41,0,0q�6o   $	��Top=�6�   $	��204��6�   ���	#7F000000
�������
�������6�   �� 5   
   -   5        $ btnDisplayPlanets��5      $ ��Display discovered Planets��6,   $
��Left=�6Q   $��	10,66,0,0q�6l   $	��Top=�6   $	��204��6�   
�������
����������	#7F0000006�   �� 5   
   -   5         ��Name$ 
txtDisplay��5      $
��Left=�6&   $	��220��6A   $��
288,14,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��317��6�   ���	#CCFFFFFF �� 
IsReadOnly . 6�   �� 5   
   -   5         ��Name$ cmbPlanetType��5      $
��Left=�6*   $��
10,140,0,0q�6E   $	��Top=�6Y   $	��120��6q   �� 5   
   $+��%Display information about planet type��6   $
��Left=�6@   $��
10,114,0,0q�6[   $	��Top=�6o   
�������6�   �� 5   
   -   5        $ btnDisplayInfo��5      $��Display��6)   $
��Left=�6;   $��135,140,0,0q�6V   $	��Top=�6k   $��75��6�   $��22��6�   ���	#7F000000
�������
�������6�   �� 5   
   $"��Learn enough today? Please -��6   $
��Left=�67   $��
10,208,0,0q�6R   $	��Top=�6f   
�������6~   �� 5   
   -   5        $ 	btnLogOut��5      $��Log Out��6$   $
��Left=�66   $��177,211,0,0q�6Q   $	��Top=�6f   $��75��6~   $��23��6�   
�������
����������	#7F0000006�   5      5      