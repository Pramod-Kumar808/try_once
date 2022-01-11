import cv2
import torch
import glob
import pandas as pd
import easyocr
import sys

print(f"Setup complete. Using torch {torch.__version__} ({torch.cuda.get_device_properties(0).name if torch.cuda.is_available() else 'CPU'})")

Path = "C:/tmp/text/"
img_number = 1 
reader = easyocr.Reader(['en'])

word_extracted = []
filename = []
for file in glob.glob(Path + "*.tif"):
    img= cv2.imread(file, 0) 
    results = reader.readtext(img, detail=0, paragraph=True) 
    word_extracted.append(results)
    filename.append(file)
    img_number +=1  

df=pd.DataFrame()
df["word"] = word_extracted
df["file"] = filename
print(df)