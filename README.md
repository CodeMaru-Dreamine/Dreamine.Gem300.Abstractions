# Dreamine.Gem300.Abstractions

Provider-neutral contracts, immutable models, and state enumerations for the
verified GEM300 domain boundary.

[➡️ 한국어 문서 보기](https://github.com/CodeMaru-Dreamine/Dreamine.Gem300.Abstractions/blob/main/README_KO.md)

The package separates object services, carrier management, substrate tracking,
process jobs, control jobs, and a process-local domain-event journal. It
references only `Dreamine.Gem.Abstractions` and `Dreamine.Secs.Abstractions`.

No concrete GEM/GEM300 implementation or communication provider is referenced.
The contracts do not imply standard wire mapping or current-revision
conformance. Equipment Performance contracts are intentionally absent until
the E116/E116.1 normative originals are available.

## License

MIT.
