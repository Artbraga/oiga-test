import { Course } from "./course.model";

export class Evaluation {
    courseId?: string;
    studentId?: string;
    studentName?: string;
    stars: number = 0;
    description: string = ''

    constructor() { }
}
