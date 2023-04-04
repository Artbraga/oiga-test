import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from 'src/model/course.model';
import { Evaluation } from 'src/model/evaluation.model';
import { Student } from 'src/model/student.model';

@Injectable({
    providedIn: 'root',
})
export class ApiService {
    private readonly baseURL = 'https://localhost:7045'
    constructor(private httpClient: HttpClient) {}

    public listCourses(): Observable<Course[]> {
        const url = this.baseURL + `/Course/ListCourses`;

        return this.httpClient.get<Course[]>(url);
    }

    public listCoursesByStudent(student: Student): Observable<Course[]> {
        const url = this.baseURL + `/Course/ListCoursesByStudent/${student.id}`;

        return this.httpClient.get<Course[]>(url);
    }

    public listStudents(): Observable<Student[]> {
        const url = this.baseURL + `/Student/ListStudents`;

        return this.httpClient.get<Student[]>(url);
    }

    public getEvaluationByCourseAndStudent(courseId: string, studentId: string): Observable<Evaluation> {
        const url = this.baseURL + `/Evaluation/GetEvaluationByCourseAndStudent/${courseId}/${studentId}`;

        return this.httpClient.get<Evaluation>(url);
    }

    public getEvaluationsByCourse(courseId: string): Observable<Evaluation[]> {
        const url = this.baseURL + `/Evaluation/GetEvaluationsByCourse/${courseId}`;

        return this.httpClient.get<Evaluation[]>(url);
    }

    public saveEvaluation(evaluation: Evaluation): Observable<boolean> {
        const url = this.baseURL + `/Evaluation/SaveEvaluation`;

        return this.httpClient.post<boolean>(url, evaluation);
    }
}
