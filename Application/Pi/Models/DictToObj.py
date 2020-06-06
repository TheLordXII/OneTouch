

class ConvertDictToObj(object):
    def __init__(self, d):
        """mappt Dictionaries (auch geschachtelt) auf Objekte."""
        for a, b in d.items():
            if isinstance(b, (list, tuple)):
               setattr(self, a, [ConvertDictToObj(x) if isinstance(x, dict) else x for x in b])
            else:
               setattr(self, a, ConvertDictToObj(b) if isinstance(b, dict) else b)