# Rebekah Myrick
# 
# Question 1
import datetime
current_time = datetime.datetime.now()
print("Current date and time:")
print(current_time.strftime("%Y-%m-%d %H:%M:%S"))

# Question 2
sample_list = ['abcdefg', 'kkzz', 'aba', '3528', '6006', '3214', 'zrkz']
count = 0
for string in sample_list:
    if len(string) >= 2 and string[0] == string[-1]:
        count += 1
print(count)

# Question 3
import itertools
sample_data = {'1': ['x', 'y', 'z'], '2': ['s', 't']}
combinations = list(itertools.product(*[sample_data[k] for k in sample_data.keys()]))
for combination in combinations:
    print(''.join(combination))

# Question 4
def replace_last_value(lst, new_value):
    return [tuple(list(t[:-1]) + [new_value]) for t in lst]
sample_list = [(10, 20, 40), (40, 50, 60), (70, 80, 90)]
new_value = 1000
new_list = replace_last_value(sample_list, new_value)
print(new_list)

# Question 5
multiline_string = '''This
is a
multiline
string.'''
lines = multiline_string.split('\n')
print(lines)