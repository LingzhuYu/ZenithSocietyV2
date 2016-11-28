export class Event {
    eventId: number;
    startDate: Date;
    endDate: Date;
    userId: string;
    creationDate: Date;
    isActive: boolean;
    activityId: number;
    activity: Object;

    constructor(obj?: any) {
        this.eventId = obj && obj.eventId || null;
        this.startDate = obj && obj.startDate || null;
        this.endDate = obj && obj.endDate || null;
        this.userId = obj && obj.userId || null;
        this.creationDate = obj && obj.creationDate || null;
        this.isActive = obj && obj.isActive || null;
        this.activityId = obj && obj.activityId || null;
    } 
}
