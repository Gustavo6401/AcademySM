import Room from "../../domain/models/apis/groups/mongo/room";
import DailyRooms from "../../infra/api/dailyRooms/dailyRooms";
import GroupsAPI from "../../infra/api/groups/groupsAPI";
import RoomsAPI from "../../infra/api/groups/roomsAPI";

export default class VideoConferenceApplicationServices {
    private dailyAPI: DailyRooms = new DailyRooms()
    private roomAPI: RoomsAPI = new RoomsAPI()
    private groupsAPI: GroupsAPI = new GroupsAPI()

    async createVideoConference(groupId: string): Promise<any> {             
        var response: string = await this.dailyAPI.createRoom()

        var idGrupo: number = Number.parseInt(groupId)

        var room = new Room('', idGrupo, response, new Date(Date.now()))
        await this.roomAPI.createAsync(room)

        return response
    }

    async getVideoConferenceUrl(groupId: string): Promise<string> {
        var idGrupo: number = Number.parseInt(groupId)

        var roomUrl: string = await this.roomAPI.getAsync(idGrupo)

        return roomUrl
    }

    async isProfessorAccessing(groupId: string): Promise<boolean> {
        const groupNumberId: number = Number.parseInt(groupId)

        return await this.groupsAPI.isProfessor(groupNumberId)
    }

    roomUrlFromPageUrl(): string | null {
        const match = window.location.search.match(/roomUrl=([^&]+)/i)

        return match && match[1] ? decodeURIComponent(match[1]) : null
    }

    pageUrlFromRoomUrl(roomUrl: string): string {
        return (
            window.location.href.split('?')[0] + (roomUrl ? `?roomUrl=${encodeURIComponent(roomUrl)}` : '')
        )
    }
}