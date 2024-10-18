import GroupsApplicationUser from "../../domain/models/apis/groups/applicationUser";
import ApplicationUser from "../../domain/models/apis/user/applicationUser";
import EducationalBackground from "../../domain/models/apis/user/educationalBackground";
import ProfilePic from "../../domain/models/apis/user/profilePic";
import GroupsApplicationUserAPI from "../../infra/api/groups/applicationUserAPI";
import ApplicationUserAPI from "../../infra/api/user/applicationUserAPI";
import EducationalBackgroundAPI from "../../infra/api/user/educationalBackgroundAPI";
import ProfilePicAPI from "../../infra/api/user/profilePicAPI";

export default class CadastroUsuarioViewServices {
    private applicationUserAPI: ApplicationUserAPI = new ApplicationUserAPI()
    private groupsApplicationUserAPI: GroupsApplicationUserAPI = new GroupsApplicationUserAPI()
    private educationalBackgroundAPI: EducationalBackgroundAPI = new EducationalBackgroundAPI()
    private profilePicAPI: ProfilePicAPI = new ProfilePicAPI()

    async create(user: ApplicationUser, groupsAppUser: GroupsApplicationUser, 
        educationalBackgrounds: Array<EducationalBackground>, profilePicture: ProfilePic) {
        const resposta = await this.applicationUserAPI.createAsync(user)
        
        var usuario = await this.applicationUserAPI.getByEmailAsync(user.getEmail())
        groupsAppUser.setId(usuario.getId())

        await this.groupsApplicationUserAPI.createAsync(groupsAppUser)

        educationalBackgrounds.forEach(async (educationalBackground) => {
            educationalBackground.setUserId(usuario.getId())

            await this.educationalBackgroundAPI.createAsync(educationalBackground)
        })

        profilePicture.setUserId(usuario.getId())

        await this.profilePicAPI.createAsync(profilePicture)

        return resposta.data
    }
}