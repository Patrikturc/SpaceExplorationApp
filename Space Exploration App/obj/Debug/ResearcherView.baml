   M S B A M L   `   `   `  ����P  LSpace Exploration App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Space_Exploration_AppSpace_Exploration_App  5   	   *    $Space_Exploration_App.ResearcherView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Space_Exploration_App     5   	     � Title$  ResearcherView��5   	   $��505.782��6    $��896.376��61   ��5	      �� 5
   
    �� ImageSource$ exoplanet.jpg��6   .��5      � .+�5   
   �� $��Hello dear Scientist��6   $
��Left=�6/   $��10,0,0,0q�6J   $	��Top=�6\   
�������6t   �� 5   
   -   5         ��Name$ btnAddSystem��5      $��Add Star System��6'   $
��Left=�6A   $��	10,57,0,0q�6\   $	��Top=�6o   $	��106��6�   ���	#7F000000
�������
�������6�   �� 5   
   -   5         ��Name$ 
txtDisplay��5      $
��Left=�6'   $	��343��6B   $��499,105,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��366��6�   ���	#CCFFFFFF �� 
IsReadOnly . 6�   �� 5   
   -   5        $ 
btnDisplay��5      $��Show All star systems��6%   $
��Left=�6E   $��
499,80,0,0q�6`   $	��Top=�6t   $	��134��6�   ���	#7F000000
�������
�������6�   �� 5   
   -   5         ��Name$ cmbAssignPlanet��5      $
��Left=�6,   $��
10,143,0,0q�6G   $	��Top=�6[   $	��162��6s   �� 5   
   -   5        $ btnAssignPlanets��5      $��Add Planets��6+   $
��Left=�6A   $��177,143,0,0q�6\   $	��Top=�6q   $	��120��6�   $��22��6�   
�������
����������	#7F0000006�   �� 5   
   $C��=Please select a star system where new planet was discovered
��6   $
��Left=�6`   $��
10,112,0,0q�6{   $	��Top=�6�   $��26��6�   
���������6�   Z� 6�   �� 5   
   -   5        $ btnRemovePlanet��5      $��Remove Planet��6*   $
��Left=�6B   $��177,321,0,0q�6]   $	��Top=�6r   $	��120��6�   $��22��6�   
�������
����������	#7F0000006�   �� 5   
   -   5        $ cmbPlanetToRemove��5      $
��Left=�6.   $��
10,321,0,0q�6I   $	��Top=�6]   $	��162��6u   �� 5   
   -   5        $ btnDisplayPlanets��5      $$��Display all discovered Planets��6,   $
��Left=�6U   $��
689,80,0,0q�6p   $	��Top=�6�   $	��176��6�   ���	#7F000000
�������
�������6�   �� 5   
   -	   5        $ 
btnRefresh��5      $��Update��6%   $
��Left=�66   $��
265,57,0,0q�6Q   $	��Top=�6e   $��75��6}   ���	#7F000000
�������
�������6�   �� 5   
   -
   5        $ cmbRemoveStar��5      $
��Left=�6*   $��
10,232,0,0q�6E   $	��Top=�6Y   $	��162��6q   �� 5   
   -   5        $ btnRemoveStar��5      $��Remove Star System��6(   $
��Left=�6E   $��177,232,0,0q�6`   $	��Top=�6u   $	��120��6�   $��22��6�   ���	#7F000000
�������
�������6�   �� 5   
   -   5        $ cmbModifyZone��5      $
��Left=�6*   $��
10,426,0,0q�6E   $	��Top=�6Y   $	��162��6q    J� RenderTransformOrigin$ 0.478,0.926&�6}   �� 5   
   -   5        $ btnModifyZone��5      $��Modify��6(   $
��Left=�69   $��347,426,0,0q�6T   $	��Top=�6i   $	��120��6�   $��22��6�   ���	#7F000000
�������
�������6�   �� 5   
   $B��<Change planets habitability zone
Please also select new zone��6   $
��Left=�6[   $��
10,380,0,0q�6v   $	��Top=�6�   $ -0.289,-0.32&�6�   $	��187��6�   $��41��6�   
�������6�   �� 5   
   $,��&Would you like to add new Star System?��6   $
��Left=�6A   $��	10,31,0,0q�6\   $	��Top=�6o   
�������6�   �� 5   
   $��Update the Window��6   $
��Left=�6,   $��
265,31,0,0q�6G   $	��Top=�6[   
�������6s   �� 5   
   -   5        $ cmbModifyTo��5      $
��Left=�6(   $��222,426,0,0q�6C   $	��Top=�6X   $	��120��6p   �� 5    
   $��Select the new zone��6   $
��Left=�6.   $��222,395,0,0q�6I   $	��Top=�6^   
�������6v   �� 5!   
   $��Select the star to remove��6   $
��Left=�64   $��
10,201,0,0q�6O   $	��Top=�6c   
�������6{   �� 5"   
   $��Select a planet to remove��6   $
��Left=�64   $��
10,290,0,0q�6O   $	��Top=�6c   
�������6{   �� 5#   
   $$��Worked enough today? Please - ��6   $
��Left=�69   $��
595,10,0,0q�6T   $	��Top=�6h   
�������6�   �� 5$   
   -   5        $ 	btnLogOut��5$      $��Log Out��6$   $
��Left=�66   $��
777,10,0,0q�6Q   $	��Top=�6e   $��75��6}   $��26��6�   
�������
����������	#7F0000006�   5%      5&      