# -*- coding: utf-8 -*-
"""
Created on Sat May 26 12:28:44 2018

@author: Admin
"""

import numpy as np
a1 = [1,2,3]
a2 = np.array(a1)
print(a2)
print(type(a2))

a3 = np.arange(0,10)
a4 = np.arange(0,10,2)
a5 = np.zeros(3)
a6 = np.zeros((3,5))
a7 = np.zeros((3,5), dtype='int')
a8 = np.ones((3,5))
a9 = np.linspace(0,10,50) # numbers bn 0 and 10 for 50 rows(size = 50)
a10 = np.eye(4) # square matrix with diagonal 1
a11 = np.random.rand(3,4) #matrix 3 rows and 4 cols and the values bn 0 and 1
a12 = np.random.randn(3,4) #matrix 3 rows and 4 cols and the values are standard dist (i.e) -1 to 1
a13 = np.random.randn(5)
a14 = np.random.randint(1,100) # gives 1 random number

a15 = np.arange(0,10)
a16 = np.arange(0,10)
a17 = a15 + a16
a18 = a15/16
a19 = a15 ** 3