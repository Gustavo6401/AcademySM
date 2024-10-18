import IMaximumCharacterStrategy from "./maximumCharacterStrategy";

export default class SymbolsStrategy implements IMaximumCharacterStrategy {
    private symbols: string = "!@#$%¨&*()£¢¬/?°\\|\":;.,><^~`´}]º{{ª=+§-_\'"

    characterValid(character: string): boolean {
        return this.symbols.includes(character)
    }

}