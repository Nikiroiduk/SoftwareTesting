import subprocess

tests = []
r = subprocess.run(["..\\ExerciseCLI\\bin\\Debug\\ExerciseCLI.exe", "-a", "1,2\\3,4\\5,6", "-b", "1,2,3\\4,5,6"], 
                    capture_output=1).stdout.decode("utf-8")
tests.append(r[29:-11])
if tests.pop() == "9, 12, 15\n19, 26, 33\n29, 40, 51":
    print("-a 1,2\\3,4\\5,6 -b 1,2,3\\4,5,6 - success")
else:
    print("-a 1,2\\3,4\\5,6 -b 1,2,3\\4,5,6 - failure")

r = subprocess.run(["..\\ExerciseCLI\\bin\\Debug\\ExerciseCLI.exe", "-a", "1,2,3\\3,4,5\\5,6,7", "-b", "1,2,3\\4,5,6\\2,3,1"], 
                    capture_output=1).stdout.decode("utf-8")
tests.append(r[29:-11])
if tests.pop() == "15, 21, 18\n29, 41, 38\n43, 61, 58":
    print("-a 1,2,3\\3,4,5\\5,6,7 -b 1,2,3\\4,5,6\\2,3,1 - success")
else:
    print("-a 1,2,3\\3,4,5\\5,6,7 -b 1,2,3\\4,5,6\\2,3,1 - failure")

r = subprocess.run(["..\\ExerciseCLI\\bin\\Debug\\ExerciseCLI.exe", "-a", "1", "-b", "3"], 
                    capture_output=1).stdout.decode("utf-8")
tests.append(r[29:-11])
if tests.pop() == "3":
    print("-a 1 -b 3 - success")
else:
    print("-a 1 -b 3 - failure")

r = subprocess.run(["..\\ExerciseCLI\\bin\\Debug\\ExerciseCLI.exe", "-a", "u", "-b", "3"], 
                    capture_output=1).stdout.decode("utf-8")
tests.append(r)
if tests.pop() == "":
    print("-a u -b 3 - success")
else:
    print("-a u -b 3 - failure")