# -*- coding: utf-8 -*-
"""
Created on Sun Mar 25 13:10:21 2018

@author: Admin
"""

import docx
import string
import re
import nltk
from nltk.tokenize import word_tokenize
from nltk.corpus import stopwords
from nltk.util import ngrams
import os
import collections


def getText(filename):
    doc = docx.Document(filename)
    fullText = ""
    for para in doc.paragraphs:
        fullText += para.text
    return fullText

data = nltk.ne_chunk(nltk.pos_tag(word_tokenize(resume)))

sentences = nltk.sent_tokenize(resume)
sentences1 = [nltk.word_tokenize(sent) for sent in sentences]
sentences2 = [nltk.pos_tag(sent) for sent in sentences1]

data = nltk.ne_chunk(nltk.pos_tag(word_tokenize(sentences)))

def ie_preprocess(document):
    sentences = nltk.sent_tokenize(document) [1]
    sentences = [nltk.word_tokenize(sent) for sent in sentences] [2]
    sentences = [nltk.pos_tag(sent) for sent in sentences] [3]

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


ner_tags = collections.Counter()
 
corpus_root = "gmb-2.2.0"   # Make sure you set the proper path to the unzipped corpus
 
for root, dirs, files in os.walk(corpus_root):
    for filename in files:
        if filename.endswith(".tags"):
            with open(os.path.join(root, filename), 'rb') as file_handle:
                file_content = file_handle.read().decode('utf-8').strip()
                annotated_sentences = file_content.split('\n\n')   # Split sentences
                for annotated_sentence in annotated_sentences:
                    annotated_tokens = [seq for seq in annotated_sentence.split('\n') if seq]  # Split words
 
                    standard_form_tokens = []
 
                    for idx, annotated_token in enumerate(annotated_tokens):
                        annotations = annotated_token.split('\t')   # Split annotations
                        word, tag, ner = annotations[0], annotations[1], annotations[3]
 
                        ner_tags[ner] += 1
 
print(ner_tags)


tagged_sentences = nltk.corpus.treebank.tagged_sents()
 
print(tagged_sentences[0])
print("Tagged sentences: ", len(tagged_sentences))
print("Tagged words:", len(nltk.corpus.brown.tagged_words()))
 