   M S B A M L   `   `   `  ����J  FElevatorProgram, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ElevatorProgramElevatorProgram  5   	        ElevatorProgram.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ElevatorProgram     5   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1000��6)    � 	Resources 5	       �� 
TargetType   UpDownImageStyle �� Property �� Value �� Triggers P� Property P� Value  PositionImageStyle  
MyTemplate � ColumnDefinitions��%�  &	        &	 �     &	 �    7   7   7  '�� �    '�� f    �� 5   
   " ��6   .�5      ��  � ��$ 50��6'   �� 5       � ��$ 50��6&    5      P� 5       � {� .  . �5      ��  �@J�Opacity$	 0.3Q�60   5      5      �� 5   
   " ��6   .�5      ��  � ��$ 0,0,20,0q�6'   �� 5       � ��$ 20��6'   �� 5       � ��$ Right=�64    5      P� 5       � {� .  . �5      ��  �@J�Opacity$ 0Q�60   5      5      �� 5    
   .R�5!      �  5"      �� 5#      $
��auto �6'   �� 5$      $
��auto �6'   �� 5%      .+�5'      �� -   5        $��0��5'      ��5)      �� *ButtonReference+{�5*      �� *ButtonUpIsEnable+.��5+      �� $��Resources/Up-icon.png��6   8��  6;   5,      �� 5-      -   5        $��1��5-      ��5/      �� *ButtonReference+{�50      �� *ButtonDownIsEnable+.��51      �� $��Resources/Down-icon.png��6   8�� 6=   52      �� 53      $��2��6   
����� �$��2q�6?   �� 54      $��2��6   $��40(�6G   $��20,0,0,0q�6U   ��6,   �� *	FloorName+6U   �� 55      $��2��6   $��Resources/OrangeIcon.png��56      8�� {�58      �� *PositionIsEnable+59      5:      �� 5>   
   " ��6   .�5?      ��  � ��
 ���� 6+   �� 5@       � ��$ 0q�60   �� 5A       � ��$ 2q�6'   5B      �� 5D   
   " ��6   .�5E      ��  � ��$ 2q�6'   5F      5H      .��5J      � $��20q�6    5K   
   �� 5L      �� 5M      $��20 �6   �� 5N      �� 5O      $��20 �6   �� 5P      .+�5S   
   �� #��[ 5T      ��5S      �� *Elevators[0].Floors+5U      �� 5W   
   $��2��6   #��[ 5X      ��5W   '   �� *Elevators[1].Floors+5Y      �� 5[   
   $��4��6   #��[ 5\      ��5[   '   �� *Elevators[2].Floors+5]      5_      5`      