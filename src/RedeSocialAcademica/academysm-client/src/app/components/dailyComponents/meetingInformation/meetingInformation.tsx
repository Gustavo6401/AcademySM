import { useMeetingState, useNetwork, useParticipantIds, useRoom } from "@daily-co/daily-react";
import './meetingInformation.css'
import { DailyMeetingState, DailyRoomInfo } from "@daily-co/daily-js";

export default function MeetingInformation() {
    const room: DailyRoomInfo | null = useRoom()
    const network = useNetwork()
    const allParticipants: string[] = useParticipantIds()
    const meetingState: DailyMeetingState | null = useMeetingState()

    return (
        <section className='meeting-Information'>
            <h1>Meeting Information</h1>
            <ul>
                <li>Estado da Reunião: {meetingState ?? 'unknown'}</li>
                <li>Id da Reunião: {room?.id ?? 'unknown'}</li>
                <li>Nome da Room: {room?.name ?? 'unknown'}</li>
                <li>Status da Rede: {network?.threshold ?? 'unknown'}</li>
                <li>Topologia da Rede: {network?.topology ?? 'unknown'}</li>
                <li>ID dos Participantes: {allParticipants.join(', ')}</li>
            </ul>
        </section>
    )
}