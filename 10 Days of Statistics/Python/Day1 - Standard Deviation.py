#!/bin/python3

import math
import os
import random
import re
import sys
from statistics import mean

#
# Complete the 'stdDev' function below.
#
# The function accepts INTEGER_ARRAY arr as parameter.
#

def stdDev(arr):
    m = mean(arr)

    comp = 0
    for i in range(len(arr)):
        comp += pow(arr[i] - m, 2)
        
    fin = round(math.sqrt(comp / len(arr)), 1)

    print(fin)

if __name__ == '__main__':
    n = int(input().strip())

    vals = list(map(int, input().rstrip().split()))

    stdDev(vals)
