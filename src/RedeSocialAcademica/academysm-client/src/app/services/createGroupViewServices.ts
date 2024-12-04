import Category from "../../domain/models/apis/groups/category";
import CategoryGroups from "../../domain/models/apis/groups/categoryGroups";
import Courses from "../../domain/models/apis/groups/courses";
import GroupsUsers from "../../domain/models/apis/groups/groupsUsers";
import CreateGroupViewModel from "../../domain/models/apis/groups/return/createGroupViewModel";
import { CategoryGroupsViewModel } from "../../domain/models/viewModels/categoryGroupsViewModel";
import GroupsAPI from "../../infra/api/groups/groupsAPI";
import GroupsCategoryAPI from "../../infra/api/groups/groupsCategoryAPI";
import GroupsUserAPI from "../../infra/api/groups/groupsUserAPI";
import ApplicationUserAPI from "../../infra/api/user/applicationUserAPI";
import data from '../assets/data/categories.json'

export default class CreateGroupViewServices {
    private groupsAPI: GroupsAPI = new GroupsAPI()
    private groupsCategoryAPI: GroupsCategoryAPI = new GroupsCategoryAPI()
    private groupsUserAPI: GroupsUserAPI = new GroupsUserAPI()
    private userAPI: ApplicationUserAPI = new ApplicationUserAPI()

    async create(groups: Courses, categoryId: number): Promise<string> {
        let result: CreateGroupViewModel = await this.groupsAPI.create(groups)

        let groupsCateogryViewModel: CategoryGroupsViewModel = {
            categoryId: categoryId,
            publicGroupId: result.getGroupId()
        }

        await this.groupsCategoryAPI.create(groupsCateogryViewModel)

        var userId: string = localStorage.getItem('userId') || ''

        var groupsUsers: GroupsUsers = new GroupsUsers(0, 'Professor', userId, result.getGroupId())
        await this.groupsUserAPI.create(groupsUsers)

        await this.userAPI.modifyAuthCookie(userId)

        return result.getMessage()
    }

    /**
     * The requisition of all categories cost to us at around 25Kb, this means that we should make an economy on 
     * our front-end.
     */
    categoryList(): Array<Category> {
        const arrayData: Array<any> = data
        const categories: Array<Category> = new Array<Category>()

        arrayData.map(({ id, name, mainCategory, icon }) => {
            categories.push(new Category(id, name, mainCategory, icon))
        })        

        return categories
    }
}