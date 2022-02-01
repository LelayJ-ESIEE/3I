import collections

class TransformedDict(collections.MutableMapping):
    """A dictionary that applies an arbitrary key-altering
    function before accessing the keys"""

    # Constructeur
    def __init__(self, *args, **kwargs):
        self.store = dict() # un dictionnaire est utilisé pour le stockage interne
        self.update(dict(*args, **kwargs))  # alimenté par les paramètres du constructeur

    # look up with transformed key
    def __getitem__(self, key):
        return self.store[key.lower()]

    # storage with transformed key
    def __setitem__(self, key, value):
        self.store[key.lower()] = value

    # delete internal dict entry
    def __delitem__(self, key):
        del self.store[key.lower()]

    # return an iterator over the internal dict
    def __iter__(self):
        return iter(self.store)

    # return len() of internal dict
    def __len__(self):
        return len(self.store)