#<OneTouch Next Gen>

### Use Case Specification: <Get drink from list>
### Version <1.0>

# 1.                  Use-Case Get drink from list
## 1.1               Brief Description
Guest can get a drink from a list at the machine.

# 2.                  Flow of Events
## 2.1               Basic Flow
![](https://github.com/TheLordXII/OneTouch/blob/master/UCs/flowcharts/GetDrinkFromListUC.png)

Guest chooses drink of a list of drinks. Machine makes the drink.

## 2.2               Alternative Flows
No data available in database. Machine tries again second time. After second time, error is shown.
# 3.                  Special Requirements
n/a

# 4.                  Preconditions
n/a

# 5.                  Postconditions
Drink is made.

# 6.                  Extension Points
n/a

# 7.                  Functional Points
![](https://github.com/TheLordXII/OneTouch/blob/master/UCs/FP/GetDrinkListPi.PNG)
|Measurement Parameter|DET|RET|FTR|
|---|---|---|---|
|Number of user input|1|1|1|
|Number of user outputs|1|1|1|
|Number of user inquiries|5|3|1|
|Number of files|5|3|1|
|Number of external interfaces|0|0|0|
