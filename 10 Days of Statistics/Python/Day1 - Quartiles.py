#!/bin/python3

import math
import os
import random
import re
import sys
import statistics

#
# Complete the 'quartiles' function below.
#
# The function is expected to return an INTEGER_ARRAY.
# The function accepts INTEGER_ARRAY arr as parameter.
#

def quartiles(arr):
    arr = sorted(arr)
    arrmiddle = int(len(arr) / 2)
    
    ft = arrmiddle if (len(arr) % 2) == 0 else arrmiddle + 1
    
    firstquart = arr[:arrmiddle]
    lastquart = arr[ft:]
    
    medians = [int(statistics.median(firstquart)), 
                    int(statistics.median(arr)), 
            int(statistics.median(lastquart))]
    
    return medians

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input().strip())

    data = list(map(int, input().rstrip().split()))

    res = quartiles(data)

    fptr.write('\n'.join(map(str, res)))
    fptr.write('\n')

    fptr.close()