# Custom API Routes

This document provides information about custom API routes. Custom API routes are custom endpoints that are mapped to existing OData endpoints.

## Contents
- [GetUniversitiesByName](#GetUniversitiesByName)

- [EnrollStudentToCourse](#EnrollStudentToCourse)

- [DisenrollStudentFromAllCourses](#DisenrollStudentFromAllCourses)

### GetUniversitiesByName
- **GET** `/api/v1/UniversitiesByName/{Count}`
  - Description: Get university names in alphabetical order.

### EnrollStudentToCourse
- **POST** `/api/v1/Students/{StudentId}/EnrollCourse/{CourseId}`
  - Description: Enroll students to a course.

### DisenrollStudentFromAllCourses
- **DELETE** `/api/v1/Students/{StudentId}/DisenrollCourses`
  - Description: Disenroll students from all courses they are enrolled in.
