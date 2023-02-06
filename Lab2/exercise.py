from enum import Enum
import math


# -1 input is not a list
#  0 input contains number <= 0
#  1 scalene
#  2 isosceles
#  3 equilateral
def defTriangle(sides):
    if (type(sides) is not list):
        return -1
    sides.sort()

    if (sides[0] <= 0):
        return 0
    
    if (sides[0] != sides[1] and 
        sides[1] != sides[2]):
        return 1
    if (sides[0] == sides[2]):
        return 3
    if (sides[0] == sides[1] or 
        sides[1] == sides[2]):
        return 2

def triangleAreaCalc(sides):
    if (type(sides) is not list):
        return -1
    sides.sort()

    if (sides[0] <= 0):
        return 0

    area = 1/4 * math.sqrt(4 * sides[0] ** 2 + sides[1] ** 2 - (sides[0] ** 2 + sides[1] ** 2 - sides[2] ** 2))

    # p = (sides[0] + sides[1] + sides[2]) / 2
    # heron's formula does'n work in some cases ex: [2, 2, 4]
    # area = math.sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]))
    return area

def exercise(sides):
    triangleType = defTriangle(sides)
    if (triangleType <= 0):
        return triangleType
    triangleArea = triangleAreaCalc(sides)
    return [Triangle(triangleType).name, triangleArea]

class Triangle(Enum):
    Scalene     = 1
    Isosceles   = 2
    Equilateral = 3


