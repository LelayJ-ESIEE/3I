from collections import Counter
from collections import defaultdict
from time import perf_counter_ns
import numpy as np

def main():
    with open('data/NotreDameDeParis.txt', encoding='utf8', mode='r') as f:
        s = f.read()

    dt_T = []
    dt_C = []
    for i in range(20):
        # print("Itération N°{:>6}".format(i+1))
        t0 = perf_counter_ns()
        d = defaultdict(int)
        for c in s:
            d[c] += 1
        l = sorted(d, key= lambda x : d[x], reverse = True)
        s = "Traditionnelle : \n    Most common : " + str(l[0:10]) + "\n    Less common : " + str(l[:-11:-1])
        t1 = perf_counter_ns()
        dt_T.append(t1 - t0)
    
        t0 = perf_counter_ns()
        c = Counter(s)
        s = "With a Counter : \n    Most common : " + str(c.most_common(10)) + "\n    Less common : " + str(c.most_common()[:-11:-1])
        t1 = perf_counter_ns()
        dt_C.append(t1 - t0)
    
    print("Pour ", i+1, "itérations :")
    print("    Moyenne T :", np.mean(dt_T)/1000, "µs")
    print("    Moyenne C :", np.mean(dt_C)/1000, "µs")
    print("    Moyenne corrigée T :", np.mean(dt_T[1:])/1000, "µs")
    print("    Moyenne corrigée C :", np.mean(dt_C[1:])/1000, "µs")
    print("dt_T =", dt_T)
    print("dt_C =", dt_C)


if __name__ == "__main__":
    main()