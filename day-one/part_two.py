with open('input', encoding='utf-8-sig') as f:
    lines = f.readlines()

oldValue = 0
increased = 0

for i,_ in enumerate(lines):
    sumOfWindow = 0 if i < 2 else float(lines[i]) + float(lines[i - 1]) + float(lines[i - 2])

    if oldValue != 0 and sumOfWindow > oldValue:
        increased = -(~increased)
    
    oldValue = sumOfWindow

print(increased)