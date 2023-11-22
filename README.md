**Definition**: CURD operation of Car Inventory

**Description**:

1.  Form Fields

    a.  You need to create one form where user can save below details of
        Car.

        i.  **Name**: Textbox

        ii. **Year**: Dropdown (Last 5 year as an Option)

        iii. Company Name (Make): Textbox

        iv. **Condition**: Radio Button (New/Used)

        v.  **Has valid Insurance**: checkbox

        vi. **Image**: File Upload (you need to save image as Physical
            file)

        vii. **Description**: Text area

    b.  You need to create a Form with above fields and then show
        listing of added cars.

        i.  Grid has paging (optional)

    c.  User can update/delete car details.

    d.  For Edit you need to redirect to create page with filling
        details and where user can update details

2.  **Technology**

    a.  You need to create Web API in asp.net core to get/update/delete
        related operations.

    b.  For Frontend you can use MVC core

3.  **Patterns / Architecture**

    a.  You can use any type of architecture whatever you have idea
        about.

    b.  You need to use Repository patten, Entity framework core for DB
        operation, Dependency Injection for service registration.

    c.  You can use middleware concepts for error handling.

    d.  You can user Microsoft SQL for database table create.

4.  **Duration**: 2 hours

