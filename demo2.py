# -*- coding: utf-8 -*-
"""
Created on Sun Mar 25 13:10:21 2018

@author: Admin
"""

import docx
import string
import re
from nltk.tokenize import word_tokenize
from nltk.corpus import stopwords
from nltk.util import ngrams


def getText(filename):
    doc = docx.Document(filename)
    fullText = ""
    for para in doc.paragraphs:
        fullText += para.text
    return fullText

filename='Devendra-net-Developer-Resume.docx'
resume = getText(filename)#.encode("ascii", "ignore")

tokens = word_tokenize(resume)
punctuations = ['(',')',';',':','[',']',',']
stop_words = stopwords.words('english')
filtered = [w for w in tokens if not w in stop_words and  not w in string.punctuation]

name  = str(filtered[0])+' ' +str(filtered[1])

email = ""
match_mail = re.search(r'[\w\.-]+@[\w\.-]+', resume)
if(match_mail != None):
    email = match_mail.group(0)

mobile = ""
match_mobile = re.search(r'((?:\(?\+91\)?)?\d{9})',resume)
if(match_mobile != None):
    mobile = match_mobile.group(0)


parsed_resume = ' '.join(filtered)
r = str(parsed_resume)

shingle = []
make_shingle = ngrams(filtered,10)
#print the shingles
for s in make_shingle:
    shingle.append(s)  
