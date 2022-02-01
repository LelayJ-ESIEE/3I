from array import array
from time import perf_counter_ns as pc
import numpy as np

def main():
    l1 = list()
    l2 = list()

    l1 = [float(i) for i in range(int(1e6))]
    l2 = [float(i) for i in range(int(-5e2),int(5e2))]

    a1 = array('f', l1)
    a2 = array('f', l2)

    s1 = set(l1)
    s2 = set(l2)

    dt_l = []
    dt_a = []
    dt_s = []

    for i in range(1000):
        cnt = 0
        t0 = pc()
        for n in l2:
            if n in l1:
                cnt += 1
        if i != 0:
            dt_l.append(pc() - t0)

        cnt = 0
        t0 = pc()
        for n in a2:
            if n in a1:
                cnt += 1
        if i != 0:
            dt_a.append(pc() - t0)

        cnt = 0
        t0 = pc()
        for n in s2:
            if n in s1:
                cnt += 1
        dt_s.append(pc() - t0)

    print("dt_l =", dt_l)
    print("dt_a =", dt_a)
    print("dt_s =", dt_s, "\n")

    print("Pour ", i+1, "itérations :")
    print("    Moyenne L :", np.mean(dt_l)/1000, "µs")
    print("    Moyenne A :", np.mean(dt_a)/1000, "µs")
    print("    Moyenne S :", np.mean(dt_s)/1000, "µs")

if __name__ == "__main__":
    main()
