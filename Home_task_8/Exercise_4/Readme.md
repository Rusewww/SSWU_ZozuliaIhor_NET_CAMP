# Генерація подій в дочірньому класі
Для генерації події в дочірньому класі спочатку потрібно визначити подію в батьківському класі за допомогою ключового слова event. Наприклад:

```
public class ParentClass {
    public event EventHandler MyEvent;
    // ...
}
```
Потім можна викликати цю подію з дочірнього класу, додавши до неї відповідний обробник. Наприклад:

```
public class ChildClass : ParentClass {
    public void RaiseEvent() {
        OnMyEvent(EventArgs.Empty);
    }

    protected virtual void OnMyEvent(EventArgs e) {
        MyEvent?.Invoke(this, e);
    }
}
```
```
public class Program {
    public static void Main() {
        var child = new ChildClass();
        child.MyEvent += ChildEventHandler;
        child.RaiseEvent();
    }

    static void ChildEventHandler(object sender, EventArgs e) {
        Console.WriteLine("Child event handled");
    }
}
```
У цьому прикладі створюється дочірній клас ChildClass, який успадковує подію MyEvent з батьківського класу ParentClass. Далі в методі RaiseEvent дочірнього класу викликається метод OnMyEvent, який спричиняє виклик обробника події. У головному методі програми Main створюється екземпляр класу ChildClass, додається обробник події і викликається метод RaiseEvent. При цьому обробник події виводить повідомлення "Child event handled".