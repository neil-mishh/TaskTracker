export interface Task {
    id: number;
    name: string;
    description: string;
    createdAt: string;
    dueDate: string;
    isCompleted: boolean;
    priority: string;
    userId: number;
}
