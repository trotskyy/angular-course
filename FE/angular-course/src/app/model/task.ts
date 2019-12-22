import { SubTask } from './sub-task';

export interface Task {
    id: number;
    name: string;
    description: string;
    createdAt: Date;
    subTasks: SubTask[];
}
