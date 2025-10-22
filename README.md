# Online Food Delivery System

## Overview

The Online Food Delivery System is a web-based application designed to connect customers with restaurants through an integrated and user-friendly platform.
The project streamlines the process of ordering food online by offering centralized restaurant listings, multiple payment options, and real-time order tracking.
It also provides dedicated management interfaces for restaurant owners and delivery agents, ensuring a seamless experience for all stakeholders.




## Objectives

The primary objectives of this system are to:

1. Develop a centralized database for restaurants, customers, and delivery agents.


2. Provide a user-friendly interface that enhances the customer’s food ordering experience.


3. Support multiple order types, including delivery, pickup, and dine-in.


4. Integrate secure payment gateways for flexible transaction options.


5. Enable real-time order tracking and status updates.


6. Incorporate a rating and review mechanism to maintain service quality.


7. Offer management tools for restaurant owners and delivery agents.


8. Establish a customer support and complaint resolution system.






## System Description

The Online Food Delivery System is designed to serve three user groups:

**1. Customers**

- Register and log in to browse restaurants by location, cuisine, and rating.

- View restaurant menus, place orders, and complete payments online.

- Track order status in real time.

- Provide ratings and feedback on restaurants and menu items.


**2. Restaurant Owners**

- Manage restaurant profiles, menus, and pricing.

- Track and fulfill incoming orders.

- View customer feedback and manage reviews.

- Communicate with delivery agents and customers when needed.


**3. Delivery Agents**

- Accept and manage delivery requests.

- Update order and delivery status dynamically.

- Rate customers and restaurants to maintain quality assurance.





## System Architecture

**Front-End**

Developed using HTML and CSS, the front end ensures a responsive and visually appealing user interface.
Key features include:

- Dynamic restaurant listings and menus.

- Interactive elements such as forms, buttons, and image galleries.

- Compatibility across desktops, tablets, and mobile devices.


**Back-End**

The back-end is implemented using ASP.NET Core with Razor Pages, providing a secure and scalable environment for handling business logic.
Key modules include:

- User Management (customers, restaurants, agents)

- Order Management (placement, tracking, updates)

- Feedback and Ratings System

- API Services for CRUD operations:

    - GetRestaurants
    
    - AddRestaurant
    
    - UpdateRestaurant
    
    - DeleteRestaurant



**Database**

A SQL-based database is used to store and manage data efficiently.
It supports relational integrity among entities such as:

- Users (customers, restaurant owners, delivery agents)

- Restaurants and Menus

- Orders and Payments

- Ratings and Feedback











