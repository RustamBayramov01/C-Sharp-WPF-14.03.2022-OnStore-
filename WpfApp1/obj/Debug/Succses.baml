   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Succses   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � WindowStyle$
  None=�5   	   
������  � AllowsTransparency .  � Title$
 Info��5   	   $	��300��6   $	��300��6#   $	��350��6/   $	��350��6?    � 	Resources 5         Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground 	 ButtonStyle32 �� 
TargetType �� Property 
 FocusVisual �� Value �� 
TargetType	 ��Name
 J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName��%d  &	        &	      &	 >     &	 ]     &	 |     &	 �     &	 �     &	 �     &	 �     &		     7 
 7   7  7  7  7  7  7  7  7  �� 5   
   $ White��6;   �� 5   
   $ White��67   �� 5   
   $ White��6>   �� 5   
   $ White��6:   �� 5   
   $ White��6<   �� 5   
   $ White��68   �� 5   
   $ White��6=   �� 5   
   $ White��69   �� 5   
   $ White��6=   �� 5   
   " ��6&   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 1q�6(   �� 5       � �� 5       �� 5!      " ��6&   .R�5"      �� $	 border��6!   #��z��61   #��z��6]   #��z��6�   
 . ._�5#      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. #
 z
 6�   #��z��6  5$       5%      P� 5&       �@��IsDefaulted . . �5'   "   �� $ border��6@   # � ��6T    � ��5(      P� 5)       �@J�IsMouseOver . . �5*   "   �� $ border��6?   8   � ��6S   �� 5+   "   $ border��6@   8   � ��6T   5,      P� 5-       � �� . . �5.   "   �� $ border��6?   8   � ��6S   �� 5/   "   $ border��6@   8   � ��6T   50      P� 51       � {� .  . �52   "   �� $ border��6?   8   � ��6S   �� 53   "   $ border��6@   8   � ��6T   �� 54   "   $ contentPresenter��6K   8 	  � ��6i   55      57      59      5:      5;      .��5=      � .+�5>   
   �� ���	#FFFFF6D2 �� CornerRadius$ 20��6(   ._�5@      �  � RowDefinitions 5B      �� 5D      6&   �� 5E      6&   .+�5I      �� $��0��6   $��2��6%   $��Icon/star.png��66   $	��100��6M   $	��100��6Y   $��	0,0,0,150q�6f   6{   �� 5K      $��1��6   
���   �$��
Successful��6<   $��25(�6N   $
��Bold"�6\   $��	0,0,0,110q�6n   $��Center=�6�   $��Center=�6�   6�   �� 5M      $��2��6   $	��120��6&   $��65��62   $ 20��6>   $��0,50,0,0q�6P   
�������._�5O      �� -   5        
�������
�������$��90��5O   P   $��50��6[   $��20(�6h   $
��Bold"�6v   
���   �#��� 	 6�   .��6�   OK6�   5Q      5T      5V      5X      5Y      