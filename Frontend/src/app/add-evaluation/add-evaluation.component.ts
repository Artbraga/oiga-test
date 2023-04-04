import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Student } from 'src/model/student.model';
import { Course } from 'src/model/course.model';
import { Evaluation } from 'src/model/evaluation.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-evaluation',
  templateUrl: './add-evaluation.component.html',
  styleUrls: ['./add-evaluation.component.scss']
})
export class AddEvaluationComponent implements OnInit {

    selectedStudent?: Student;
    students: Student[] = [];
    selectedCourse?: Course;
    courses: Course[] = [];
    evaluation: Evaluation = new Evaluation();;

    constructor(private apiService: ApiService, public router: Router) { }

    ngOnInit(): void {
        this.apiService.listStudents().subscribe(data => {
            this.students = data.map(x => new Student(x.id, x.name, x.lastName, new Date(x.creationDate), x.active));
        });
    }

    onSelectStudent() {
        this.selectedCourse = undefined;
        this.apiService.listCoursesByStudent(<Student>this.selectedStudent).subscribe(data => {
            this.courses = data.map(x => new Course(x.id, x.name, new Date(x.creationDate), x.active));
        });
    }

    onSelectCourse() {
        if (this.selectedStudent != null && this.selectedCourse != null)  {
            this.evaluation = new Evaluation();
            this.apiService.getEvaluationByCourseAndStudent(this.selectedCourse.id, this.selectedStudent.id).subscribe(data => {
                this.evaluation.courseId = this.selectedCourse?.id;
                this.evaluation.studentId = this.selectedStudent?.id;
                if (data != null) {
                    this.evaluation.stars = data.stars;
                    this.evaluation.description = data.description;
                }
            });
        }
    }

    saveEvaluation() {
        this.apiService.saveEvaluation(<Evaluation>this.evaluation).subscribe(data => {
            if (data) {
                this.router.navigate(['courses']);
            }
        })
    }
}
