import { DailyVideo, useVideoTrack } from "@daily-co/daily-react";
import Username from "../username/username";
import './tile.css'

interface TileProperties {
    id: string,
    isScreenShare: boolean,
    isLocal: boolean,
    isAlone: boolean,
    mirror: boolean
}

const Tile: React.FC<TileProperties> = ({ id, isScreenShare, isLocal, isAlone, mirror }) => {
    console.log(id)
    console.log(isScreenShare)
    console.log(isLocal)
    console.log(isAlone)
    console.log(mirror)

    const videoState = useVideoTrack(id)

    let containerCssClasses = isScreenShare ? 'tile-screenshare' : 'tile-video'

    if (isLocal) {
        containerCssClasses += ' self-view'

        if (isAlone) {
            containerCssClasses += ' alone'
        }
    }

    if (videoState.isOff) {
        containerCssClasses += ' no-video'
    }

    return (
        <div className={containerCssClasses}>
            <DailyVideo automirror={true} sessionId={id} type={isScreenShare ? 'screenVideo' : 'video'} mirror={mirror} />
            {!isScreenShare && <Username id={id} isLocal={isLocal} />}
        </div>
    )
}

export default Tile