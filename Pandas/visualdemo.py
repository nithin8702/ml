# -*- coding: utf-8 -*-
"""
Created on Sun May 27 15:33:32 2018

@author: Admin
"""

#bokeh, seaborn, vincent, cufflinks

import matplotlib.pyplot as plt
import numpy as np

x = np.linspace(0,5,11)
y =  x ** 2

plt.plot(x,y)
plt.show()

plt.xlabel('X Label')
plt.ylabel('Y Label')
plt.title('X and Y co-relation')
plt.plot(x,y,'r')

import quandl