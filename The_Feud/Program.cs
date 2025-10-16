// See https://aka.ms/new-console-template for more information

// Challenge: The Feud

using IField;
using McDroid;

using FieldPig = IField.Pig;
using DroidPig = McDroid.Pig;

Sheep sheep = new Sheep();
Cow cow = new Cow();
FieldPig fieldPig = new FieldPig();
DroidPig droidPig = new DroidPig();


namespace IField
{
    public class Sheep { }
    public class Pig { }
}

namespace McDroid
{
    public class Cow { }
    public class Pig { }
}