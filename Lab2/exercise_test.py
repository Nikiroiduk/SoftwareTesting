from exercise import Triangle
from exercise import triangleAreaCalc
from exercise import defTriangle
from exercise import math

def defTriangleTest_Equilateral():
    if (defTriangle([2, 2, 2]) == Triangle['Equilateral'].value):
        return 0
    return -1

def defTriangleTest_Isosceles():
    if (defTriangle([2, 2, 4]) == Triangle['Isosceles'].value):
        return 0
    return -1

def defTriangleTest_Scalene():
    if (defTriangle([2, 1, 3]) == Triangle['Scalene'].value):
        return 0
    return -1

def defTriangleTest_NegativeSide():
    if (defTriangle([-2, 1, 3]) == 0):
        return 0
    return -1

def defTriangleTest_ZeroSide():
    if (defTriangle([0, 0, 3]) == 0):
        return 0
    return -1

def defTriangleTest_WrongType():
    if (defTriangle(1) == -1):
        return 0
    return -1

def triangleAreaCalcTest_CorrectTriangle():
    if (math.isclose(triangleAreaCalc([2, 2, 4]), 1.32, rel_tol = .01)):
        return 0
    return -1

def triangleAreaCalcTest_WrongType():
    if (triangleAreaCalc(3) == -1):
        return 0
    return -1

def triangleAreaCalcTest_NegativeSide():
    if (triangleAreaCalc([0, 1, 0]) == 0):
        return 0
    return -1

def triangleAreaCalcTest_ZeroSide():
    if (triangleAreaCalc([0, -1, -2]) == 0):
        return 0
    return -1

print('defTriangleTest_Equilateral : {}' .format('Ok' if (defTriangleTest_Equilateral() == 0)  else 'Fail'))
print('defTriangleTest_Isosceles : {}'   .format('Ok' if (defTriangleTest_Isosceles() == 0)    else 'Fail'))
print('defTriangleTest_Scalene : {}'     .format('Ok' if (defTriangleTest_Scalene() == 0)      else 'Fail'))
print('defTriangleTest_NegativeSide : {}'.format('Ok' if (defTriangleTest_NegativeSide() == 0) else 'Fail'))
print('defTriangleTest_ZeroSide : {}'    .format('Ok' if (defTriangleTest_ZeroSide() == 0)     else 'Fail'))
print('defTriangleTest_WrongType : {}'   .format('Ok' if (defTriangleTest_WrongType() == 0)    else 'Fail'))

print('triangleAreaCalcTest_CorrectTriangle : {}'.format('Ok' if (triangleAreaCalcTest_CorrectTriangle() == 0) else 'Fail'))
print('triangleAreaCalcTest_WrongType : {}'      .format('Ok' if (triangleAreaCalcTest_WrongType() == 0)       else 'Fail'))
print('triangleAreaCalcTest_NegativeSide : {}'   .format('Ok' if (triangleAreaCalcTest_NegativeSide() == 0)    else 'Fail'))
print('triangleAreaCalcTest_ZeroSide : {}'       .format('Ok' if (triangleAreaCalcTest_ZeroSide() == 0)        else 'Fail'))


