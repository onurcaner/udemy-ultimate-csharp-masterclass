📘 Code Style Guide (based on .editorconfig)
This project enforces strict Microsoft C# naming and qualification conventions. The rules are applied automatically in Rider and Visual Studio via .editorconfig.

🔹 Fields
Private instance fields → _camelCase  
Example: _customerId

Private static fields → s_camelCase  
Example: s_cache

Private readonly fields → _camelCase  
Example: _repository

Constants (public or private) → PascalCase
Example: MaxItems

🔹 Members
Public methods, properties, fields → PascalCase
Example: GetCustomer()

Interfaces → IPascalCase  
Example: IRepository

🔹 Types
Classes, structs, records → PascalCase
Example: OrderService

Enums → PascalCase
Example: Color

Enum members → PascalCase
Example: Red, Green, Blue

Namespaces → PascalCase (no underscores)
Example: MyCompany.MyProduct.MyFeature

🔹 Generics
Type parameters → TPascalCase  
Example: TKey, TValue

🔹 Delegates & Events
Delegates → PascalCase
Example: ProcessCompleted

Event handler delegates → PascalCase ending with Handler  
Example: MouseEventHandler

Callback delegates → PascalCase ending with Callback  
Example: AsyncCallback

Events → PascalCase (no On prefix)
Example: DataReceived

Event‑raising methods → PascalCase with On prefix
Example: OnDataReceived()

🔹 Locals & Parameters
Local variables and parameters → camelCase  
Example: orderId, customerName

🔹 Async Methods
Async methods → PascalCase ending with Async  
Example: SaveAsync()

🔹 Qualification Rules
Require this. for all instance member access  
Example:

csharp
this._customerId = id;
this.SaveAsync();
🎯 Summary
This configuration ensures:

Consistent naming across fields, members, types, generics, delegates, events, locals, async methods, and namespaces.

Strict enforcement of Microsoft guidelines.

Rider and Visual Studio will both flag violations.

Code stays predictable, readable, and robust.