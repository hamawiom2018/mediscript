import { Doctor } from "./doctor.model";
import { Patient } from "./patient.model";

export interface Visit {
    id: number;
    date: string;
    patient:Patient;
    doctor:Doctor;
}
export var visitsVar: Visit[]=[
    {date:'2023-04-05',
    doctor:{id:1,name:'Ahmed',age:30},
    patient:{id:1,name:'Mohammed',age:55,gender:'male',allergies:['dust','penicillin'],chronicDiseases:['diabetes','hypertension']},
    id:1},
    {date:'2023-04-05',
    doctor:{id:1,name:'Ahmed',age:30},
    patient:{id:2,name:'Hasan',age:55,gender:'male',allergies:['dust','pollen'],chronicDiseases:['diabetes','hypertension']},
    id:2}
  ];