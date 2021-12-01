with open('input', encoding='utf-8-sig') as f:
    lines = f.readlines()

oldValue = 0
increased = 0

for i,_ in enumerate(lines):
    val = float(lines[i])

    if oldValue != 0 and val > oldValue:
        increased = -(~increased)
    
    oldValue = val

print(increased)