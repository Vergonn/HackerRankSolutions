#!/bin/python3

import math
import os
import random
import re
import sys
from statistics import median

#
# Complete the 'interQuartile' function below.
#
# The function accepts following parameters:
#  1. INTEGER_ARRAY values
#  2. INTEGER_ARRAY freqs
#

def interQuartile(values, freqs):
    arr = []    
    for i in range(n):
        arr += [values[i]] * freq[i]        

    arr.sort()
    
    middle = len(arr) // 2    
    if n % 2 != 0:
        lm = median(arr[:middle])
        um = median(arr[middle+1:])
    else:
        lm = median(arr[:middle])
        um = median(arr[middle:])
    
    fin = round(float(um - lm), 1)
    
    print(fin)
    
    # Print your answer to 1 decimal place within this function

if __name__ == '__main__':
    n = int(input().strip())

    val = list(map(int, input().rstrip().split()))

    freq = list(map(int, input().rstrip().split()))

    interQuartile(val, freq)