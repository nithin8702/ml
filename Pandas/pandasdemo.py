# -*- coding: utf-8 -*-
"""
Created on Sat May 26 13:32:41 2018

@author: Admin
"""

# Panel-Data
# Open Source
# CSV, Text files, Excel, SQL, etc
# Great interaction with data visualization libraries like matplotlib and seaborn
# Highly optimized for perf with critical code paths written in c

# series are similar to numpy array except that we can give them a named index

import pandas as pd
import numpy as np

mylist = [10,20,30]
s1 = pd.Series(mylist)
s2 = pd.Series(mylist, index=['a','b','c'])
s2['a']
s2[ s2 > 10]
s3 = s2[ (s2 > 10) & (s2 < 30)]
s2[ s2 == 20]
s2[ s2 == 20] = 60
s4 = pd.Series([40,50,60])
s5 = s1 + s4
s6 = pd.Series(['one','two','three'])

df1 = pd.DataFrame(data=np.random.randn(5,4),index=['A','B','C','D','E'],columns=['col1','col2','col3','col4'])
df1['col1']
df1[['col1','col2']] # columns
df1.loc['C'] # index
df1.loc[['C','D']]
df1.iloc[0]
df1.iloc[[0,2]]
df1['new'] = df1['col1'] + df1['col2']
df1.drop('new',axis=1) # drop new olumns, axis =1 is column, axis =0 is index
df1.drop('new',axis=1,inplace=True)
df1.drop('D',axis=0)
df1 [df1 > 0 ]
df1 [df1 > 0 ]['col1']
df1 [df1 > 0 ][['col1','col3']]
df1 [df1 > 0 ].dropna()
df1 [df1 > 0 ].fillna(0)
df1 [df1 > 0 ].fillna(value='EMPTY')
df1 [df1 > 0 ].fillna(value=df1['col1'].mean())



data = {
        'company':['GOOG','GOOG','MSFT','MSFT','FB','FB'],
        'person':['sam','charlie','amy','vanessa','carl','sarah'],
        'sales':[200,120,340,124,243,350]
        }
df2 = pd.DataFrame(data)
df2.describe()
df1.describe()
bycomp = df2.groupby('company')
df2['company'].unique()
bycomp.mean()
bycomp.sum()
bycomp.max()

df3 = pd.DataFrame({
        'A':['A0','A1','A2','A3'],
        'B':['B0','B1','B2','B3']
        })

df4 = pd.DataFrame({
        'A':['A4','A5','A6','A7','A8'],
        'B':['B5','B5','B6','B7','B8']
        })

df5 = pd.concat([df3,df4])
df5.reset_index(inplace=True)
df6 = pd.concat([df3,df4],axis=1)


df7 = pd.DataFrame({
            'key':['ko','k1','k2','k3'],
            'A':['A0','A1','A2','A3'],
            'B':['B0','B1','B2','B3']
        })

df8 = pd.DataFrame({
            'key':['ko','k1','k2','k4'],
            'C':['C0','C1','C2','C3'],
            'D':['D0','D1','D2','D3']
        })
df9 = pd.merge(df7,df8,how='inner',on='key')
df10 = pd.merge(df7,df8,how='right',on='key')
df11 = pd.merge(df7,df8,how='left',on='key')
df12 = pd.merge(df7,df8,how='outer',on='key')

def times2(x):
    return x *2
df2['sales'].apply(times2)
df2['sales'].apply(lambda x : x * 2)
df2.drop('person', axis = 1) #drop column
df2.index
df2.sort_values(by='sales',ascending=False)

df2['sales'].hist()
df2['sales'].plot(kind='hist')
df2['sales'].plot(kind='pie')
df2['new'] = df2['sales'] * 2 
df2.plot.scatter(x='sales', y='new')